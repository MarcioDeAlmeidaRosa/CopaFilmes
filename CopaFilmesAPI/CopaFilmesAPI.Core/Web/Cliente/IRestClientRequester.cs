using RestSharp;
using System.Threading.Tasks;
using CopaFilmesAPI.Core.Responses;

namespace CopaFilmesAPI.Core.Web.Cliente
{
    /// <summary>
    /// Responsável por definir o contrato de iterações com API REST externas
    /// </summary>
    public interface IRestClientRequester
    {
        /// <summary>
        /// Executa requisição com método GET à URl solicitada
        /// </summary>
        /// <typeparam name="T">Definição do tipo que será retornado pela requisção</typeparam>
        /// <param name="resourceName">Action que será acessada da API REST</param>
        /// <param name="filterRequest">Parâmetros para filtro da API REST</param>
        /// <returns>Retorno da API REST, sendo a crírica ou o resultado esperador</returns>
        Task<CopaFilmesAPIResponse<T>> Get<T>(string resourceName, object filterRequest = null) where T : class;

        /// <summary>
        /// Executa requisição com método GET à URl solicitada
        /// </summary>
        /// <typeparam name="T">Definição do tipo que será retornado pela requisção</typeparam>
        /// <param name="resourceName">Action que será acessada da API REST</param>
        /// <param name="method">Verbo que será executado na requisição</param>
        /// <param name="filterRequest">Parâmetros para filtro da API REST</param>
        /// <param name="body">Body para filtro da API REST</param>
        /// <returns>Retorno da API REST, sendo a crírica ou o resultado esperador</returns>
        Task<CopaFilmesAPIResponse<T>> GetResponse<T>(string resourceName, Method method, object filterRequest = null, object body = null) where T : class;
    }
}
