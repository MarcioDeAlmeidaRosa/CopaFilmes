using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CopaFilmesAPI.Core.Exceptions;
using CopaFilmesAPI.Core.Infraestrutura.Extensions;
using CopaFilmesAPI.Core.Infraestrutura.Serialization;

namespace CopaFilmesAPI.Core.Responses
{
    /// <summary>
    /// Representa a resposta do processamento da API
    /// </summary>
    public class CopaFilmesAPIResponse
    {
        /// <summary>
        /// Statis do código que foi retornado pela chamada REST
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Lista de erros retorna pela chamada
        /// </summary>
        public IEnumerable<string> Erros { get; set; } = new List<string>();

        /// <summary>
        /// Controle de a resposta é de sucesso ou erro
        /// </summary>
        public virtual bool Sucesso => !Erros.Any();
        
        /// <summary>
        /// Inicializa uma instância de resposta
        /// </summary>
        public CopaFilmesAPIResponse()
        {
        }

        /// <summary>
        /// /// Inicializa uma instância de resposta
        /// </summary>
        /// <param name="responseContent">string que será verificada se é erro</param>
        public CopaFilmesAPIResponse(string responseContent)
        {
            VerificaErros(responseContent);
        }

        /// <summary>
        /// Verifica se o objeto JSON da resposta tem erro
        /// </summary>
        /// <param name="responseContent">JSON de resposta</param>
        /// <param name="exception">Exception que será incluída na lsita de erro</param>
        protected void VerificaErros(string responseContent, Exception exception = null)
        {
            var errorsFromResponse = responseContent
                .ExtractErrors()
                .ToList();

            if (errorsFromResponse.Any())
            {
                Erros = errorsFromResponse;
            }
            else
            {
                var exceptionMessage = exception?.ToString() ?? string.Empty;

                Erros = new[]
                {
                    $"{exceptionMessage}\nConteúdo: {responseContent}"
                };
            }
        }

        /// <summary>
        /// Lança exception caso existe erros no objeto de resposta
        /// </summary>
        /// <returns>Retprma p próprio objeto se sucesso ou um erro</returns>
        public virtual CopaFilmesAPIResponse ThrowSeErros()
        {
            if (Sucesso)
            {
                return this;
            }

            var errors = Erros?.Any() == true
                ? Erros
                : new List<string> { $"Retorno sem mensagens de erros [StatusCode: {StatusCode}]." };

            throw new CopaFilmesAPIException(errors);
        }
    }

    /// <summary>
    /// Responsável por auxiliar na conversão da resposta em um objeto do tipo <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CopaFilmesAPIResponse<T>: CopaFilmesAPIResponse where T : class
    {

        /// <summary>
        /// Objeto convertido para ser retornado como resposta
        /// </summary>
        public T Conteudo { get; }

        /// <summary>
        /// Inicializa uma instância de resposta
        /// </summary>
        public CopaFilmesAPIResponse()
        {

        }

        /// <summary>
        /// /// Inicializa uma instância de resposta
        /// </summary>
        /// <param name="conteudoResposta">JSON contendo o objeto que será retornado como resposta</param>
        public CopaFilmesAPIResponse(string conteudoResposta)
        {
            Conteudo = conteudoResposta.DeserializeJSON<T>();
        }

        /// <summary>
        /// Verifica se é um tipo
        /// </summary>
        /// <returns></returns>
        internal bool IsValueType()
        {
            return typeof(T).IsValueType && !IsString();
        }

        /// <summary>
        /// Verifica se o tipo é string
        /// </summary>
        /// <returns></returns>
        internal bool IsString()
        {
            return typeof(T) == typeof(string);
        }

        /// <summary>
        /// Lança exception se a respota contem algum erro
        /// </summary>
        /// <returns>objeto de resposta caso não existe erro</returns>
        public CopaFilmesAPIResponse<T> ThrowSeRespostaComErros()
        {
            if (Sucesso)
            {
                return this;
            }

            var errors = Erros?.Any() == true
                ? Erros
                : new List<string> { $"Retorno sem conteúdo e/ou sem mensagens de erros [StatusCode: {StatusCode}]." };

            throw new CopaFilmesAPIException(errors);
        }
    }
}
