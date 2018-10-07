using System;

namespace CopaFilmesAPI.Core.Web.Cliente
{
    /// <summary>
    /// Responsável por fabricar cliente para requisição para API REST
    /// </summary>
    public class RestClientFactory : IRestClientFactory
    {
        /// <summary>
        /// Executa a criação de um cliente para requisição rest
        /// </summary>
        /// <param name="baseURL">URL que será chamada ao executar a requisição</param>
        /// <returns>Instância do cliente Rest para requisição a API Rest</returns>
        public IRestClientRequester Create(string baseURL)
        {
            return new RestClientRequester(baseURL);
        }
    }
}
