using System;
using RestSharp;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Responses;
using CopaFilmesAPI.Core.Infraestrutura.Extensions;
using CopaFilmesAPI.Core.Infraestrutura.Serialization;

namespace CopaFilmesAPI.Core.Web.Cliente
{
    /// <summary>
    /// REsponsável por executar o consulmo da API Rest
    /// </summary>
    public class RestClientRequester : IRestClientRequester
    {
        /// <summary>
        /// Lista de códigos de erro que poderão ser retornadas do request 
        /// </summary>
        private static readonly HttpStatusCode[] ErrorsStatus = { HttpStatusCode.NotFound, HttpStatusCode.InternalServerError, (HttpStatusCode)422 };

        /// <summary>
        /// Armazena instância de um cliente rest
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="baseUrl">URL para ser chamada</param>
        public RestClientRequester(string baseUrl) : this(new RestClient(baseUrl))
        {
        }

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="restClient">Instancia cliente rest</param>
        public RestClientRequester(IRestClient restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// Executa requisição com método GET à URl solicitada
        /// </summary>
        /// <typeparam name="T">Definição do tipo que será retornado pela requisção</typeparam>
        /// <param name="resourceName">Action que será acessada da API REST</param>
        /// <param name="filterRequest">Parâmetros para filtro da API REST</param>
        /// <returns>Retorno da API REST, sendo a crírica ou o resultado esperador</returns>
        public async Task<CopaFilmesAPIResponse<T>> Get<T>(string resourceName, object filterRequest = null) where T : class
        {
            return await GetResponse<T>(resourceName, Method.GET, filterRequest);
        }

        /// <summary>
        /// Executa requisição com método GET à URl solicitada
        /// </summary>
        /// <typeparam name="T">Definição do tipo que será retornado pela requisção</typeparam>
        /// <param name="resourceName">Action que será acessada da API REST</param>
        /// <param name="method">Verbo que será executado na requisição</param>
        /// <param name="filterRequest">Parâmetros para filtro da API REST</param>
        /// <param name="body">Body para filtro da API REST</param>
        /// <returns>Retorno da API REST, sendo a crírica ou o resultado esperador</returns>
        public async Task<CopaFilmesAPIResponse<T>>  GetResponse<T>(string resourceName, Method method, object filterRequest = null, object body = null) where T : class
        {
            try
            {
                var restRequest = CreateRequest(resourceName, filterRequest, method, body);
                var restResponse =  await _restClient.ExecuteTaskAsync(restRequest);

                return restResponse.StatusCode.In(ErrorsStatus)
                    ? HandleErrors<T>(restResponse)
                    : new CopaFilmesAPIResponse<T>(restResponse.Content)
                    {
                        StatusCode = restResponse.StatusCode
                    };
            }
            catch (Exception exception)
            {
                return new CopaFilmesAPIResponse<T>
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Erros = new[] { exception.Message }
                };
            }
        }

        /// <summary>
        /// Cria objeto rest que será usado para chamar uma API 
        /// </summary>
        /// <param name="resourceName">action que será chamada</param>
        /// <param name="filterRequest">filtro que será enviado na chamada da API</param>
        /// <param name="method">Verbo para chamada da API</param>
        /// <param name="bodyContent">body para envio a API</param>
        /// <param name="timeoutInSeconds">Configuração de tempo de espera para resposta</param>
        /// <returns></returns>
        internal static IRestRequest CreateRequest(string resourceName = null, object filterRequest = null, Method method = Method.GET, object bodyContent = null, int timeoutInSeconds = 0)
        {
            RestRequest restRequest;

            if (string.IsNullOrEmpty(resourceName))
            {
                restRequest = new RestRequest(method)
                {
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new ResharpJsonSerializer()
                };
            }
            else
            {
                restRequest = new RestRequest(resourceName, method)
                {
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new ResharpJsonSerializer(),
                };
            }

            if (timeoutInSeconds > 0)
            {
                restRequest.Timeout = timeoutInSeconds * 1000;
            }

            if (filterRequest != null)
            {
                restRequest.AddParameters(filterRequest);
            }

            if (method == Method.POST || method == Method.PUT || method == Method.DELETE)
            {
                restRequest.AddBody(bodyContent);
            }

            return restRequest;
        }

        /// <summary>
        /// Controla os erros da resposta da API
        /// </summary>
        /// <typeparam name="T">Tipo do objeto de resposta</typeparam>
        /// <param name="restResponse">objeto contendo a resposta da API</param>
        /// <returns>Resposta contendo o objeto esperado um uma lista de erro</returns>
        internal CopaFilmesAPIResponse<T> HandleErrors<T>(IRestResponse restResponse) where T : class
        {
            if (restResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new CopaFilmesAPIResponse<T>
                {
                    StatusCode = restResponse.StatusCode,
                    Erros = new[] { "Serviço não encontrado." }
                };
            }

            var errorsFromResponse = restResponse
                .Content
                .ExtractErrors()
                .ToList();

            return new CopaFilmesAPIResponse<T>
            {
                StatusCode = restResponse.StatusCode,
                Erros = errorsFromResponse.Any()
                    ? errorsFromResponse
                    : new List<string> { $"[{restResponse.StatusCode}] - {restResponse.StatusDescription}" }
            };
        }
    }
}
