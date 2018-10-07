namespace CopaFilmesAPI.Core.Web.Cliente
{
    /// <summary>
    /// Define o método de contrução da factory do resquest
    /// </summary>
    public interface IRestClientFactory
    {
        /// <summary>
        /// Responsável por criar a instância do rest cliente
        /// </summary>
        /// <param name="baseURL"></param>
        /// <returns></returns>
        IRestClientRequester Create(string baseURL);
    }
}
