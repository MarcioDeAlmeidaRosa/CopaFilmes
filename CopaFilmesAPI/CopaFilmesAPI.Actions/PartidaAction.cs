using System.Linq;
using CopaFilmesAPI.DAO;
using CopaFilmesAPI.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using CopaFilmesAPI.Model.Converts;

namespace CopaFilmesAPI.Actions
{
    /// <summary>
    /// Responsável por processar a partida
    /// </summary>
    public class PartidaAction
    {
        /// <summary>
        /// Responsável por armazenar a instância do DAO para acesso aos dados
        /// </summary>
        private FilmeDAO _dao;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        public PartidaAction()
        {
            _dao = new FilmeDAO();
        }

        /// <summary>
        /// Executa a partida para retornar o campeão e o vice
        /// </summary>
        /// <param name="filmesEscolhidos"></param>
        /// <returns>Lista de Filme contendo o campeão e vice campeão</returns>
        public async Task<IEnumerable<Filme>> ProcessaCampeonato(string[] filmesEscolhidos)
        {
            var filmes = await _dao.Listar();
            return filmes
                .Where(f => filmesEscolhidos.Contains(f.ID))
                .MontarChaveamentoInicial()
                .ExecutarEliminatorias()
                .ExecutaPartidaFinal();
        }
    }
}
