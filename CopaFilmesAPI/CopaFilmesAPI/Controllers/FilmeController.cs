using System;
using System.Net;
using System.Net.Http;
using CopaFilmesAPI.DAO;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Controllers
{
    /// <summary>
    /// Disponibiliza funcionalidades de filme
    /// </summary>
    public class FilmeController : BaseController
    {
        /// <summary>
        /// Variável de referência para armazenar a instância do DAO
        /// </summary>
        private FilmeDAO _dao;

        /// <summary>
        /// Contrutor para instância da classe
        /// </summary>
        public FilmeController()
        {
            _dao = new FilmeDAO();
        }

        /// <summary>
        /// Fornece lista de Filme para o cliente
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _dao.Listar());
            }
            catch (Exception ex)
            {
                return InternalErro(ex);
            }
        }
    }
}
