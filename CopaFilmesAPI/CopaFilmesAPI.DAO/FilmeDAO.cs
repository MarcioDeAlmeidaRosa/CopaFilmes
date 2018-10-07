using System;
using System.Linq;
using CopaFilmesAPI.Model;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Web.Cliente;

namespace CopaFilmesAPI.DAO
{
    /// <summary>
    /// Responsável por fornecer recursos de filme para a API
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
        /// Responsável Filme pelo <paramref name="filter"/>
        /// </summary>
        /// <param name="filter">Filtro do filme</param>
        /// <returns>Entidade <typeparamref name="T"/> localizada pelo filtro informado</returns>
        /// <exception cref="ArgumentException"> Exceção lançada quando o <paramref name="filter"/> for nulo</exception>
        public async Task<Filme> BuscarPorId(Filme filter)
        {
            if (filter == null) throw new ArgumentException("Filtro não informado.", nameof(filter));
            var filmes = await LerAPIFilme(filter);
            return filmes.FirstOrDefault();
        }

        /// <summary>
        /// Responsável por recuperar lista de Filme
        /// </summary>
        /// <returns>Lista da entidade Filme localizada</returns>
        public async Task<IEnumerable<Filme>> Listar()
        {
            return await LerAPIFilme();
        }

        /// <summary>
        /// Responsável por consumir os dados da URL
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<Filme>> LerAPIFilme(object questionarioRequest = null)
        {
            var retorno = await _restClientFactory
                .Create(ConfigurationManager.AppSettings["URL_API_FILMES"])
                .Get<List<Filme>>("filmes", filterRequest: questionarioRequest);
            retorno.ThrowSeRespostaComErros();
            return retorno.Conteudo;
        }
    }
}
