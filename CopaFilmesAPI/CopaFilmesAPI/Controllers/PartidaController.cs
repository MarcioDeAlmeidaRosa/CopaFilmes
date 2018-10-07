using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaFilmesAPI.Actions;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Controllers
{
    /// <summary>
    /// Responsável por executar partidas do campeonato
    /// </summary>
    public class PartidaController : BaseController
    {
        /// <summary>
        /// Variável para armazenar a instância da ação
        /// </summary>
        private readonly PartidaAction _actions;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        public PartidaController()
        {
            _actions = new PartidaAction();
        }

        /// <summary>
        /// Processa o campeonato conforme escolha dos filmes
        /// </summary>
        /// <returns>Retorna resultado conendo o campeão e o segundo colocado</returns>
        public async Task<HttpResponseMessage> Post([FromBody]string[] filmesEscolhidos)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _actions.ProcessaCampeonato(filmesEscolhidos));
            }
            catch (Exception ex)
            {
                return InternalErro(ex);
            }
        }
    }
}
