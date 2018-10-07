using CopaFilmesAPI.Model;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Web.Cliente;

namespace CopaFilmesAPI.DAO
{
    /// <summary>
    /// Responsável por fornecer recursos de filme
    /// </summary>
    public class FilmeDAO : IDAO<Filme>
    {
        /// <summary>
        /// Armazena a referência da factory de um cliente rest
        /// </summary>
        private readonly IRestClientFactory _restClientFactory;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        public FilmeDAO()
        {
            _restClientFactory = new RestClientFactory();
        }

        /// <summary>
        /// Responsável por recuperar lista de Filme
        /// </summary>
        /// <returns>Lista da entidade Filme localizada</returns>
        public async Task<IEnumerable<Filme>> Listar()
        {
            var retorno = await _restClientFactory
                .Create(ConfigurationManager.AppSettings["URL_API_FILMES"])
                .Get<List<Filme>>("filmes");
            retorno.ThrowSeRespostaComErros();
            return retorno.Conteudo;
        }
    }
}
