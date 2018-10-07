using CopaFilmesAPI.DAO;
using CopaFilmesAPI.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CopaFilmesAPI.Actions
{
    /// <summary>
    /// Responsável por fornecer recursos de filme para a API
    /// </summary>
    public class FilmeActions
    {
        /// <summary>
        /// Responsável por armazenar a instância do DAO para acesso aos dados
        /// </summary>
        private FilmeDAO _dao;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        public FilmeActions()
        {
            _dao = new FilmeDAO();
        }

        /// <summary>
        /// Responsável por recuperar lista de Filme
        /// </summary>
        /// <returns>Lista da entidade Filme localizada</returns>
        public async Task<IEnumerable<Filme>> Listar()
        {
            return await _dao.Listar();
        }
    }
}
