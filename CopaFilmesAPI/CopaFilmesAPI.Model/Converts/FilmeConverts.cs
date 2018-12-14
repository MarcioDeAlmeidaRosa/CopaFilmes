using System;
using System.Linq;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Exceptions;

namespace CopaFilmesAPI.Model.Converts
{
    /// <summary>
    /// Responsável por auxiliar na execução das rodadas
    /// </summary>
    public static class FilmeConverts
    {
        /// <summary>
        /// Monta o chavemento inicial para começar o compeonato
        /// </summary>
        /// <param name="filmes">Lista de filmes para o sorteio de chave do campeonato</param>
        /// <exception cref="ArgumentNullException">Retornando quando a lista de filme for nula</exception>
        /// <exception cref="NotFoundException">Retornado quando não existir filme para iniciar a chave do campeonato</exception>
        /// <exception cref="CopaFilmesAPIValidationException">Não é permitido executar o campeonato com número impar de time</exception>
        /// <returns>Listas de chaves para iniciar o campeonato</returns>
        public static IEnumerable<Filme>[] MontarChaveamentoInicial(this IEnumerable<Filme> filmes)
        {
            if (filmes?.Count() == 0) throw new NotFoundException("Não localizado filme para iniciar a chave.");
            if ((filmes.Count() % 2) > 0) throw new CopaFilmesAPIValidationException("Não permitido quantidade ímpar para iniciar o campeonato.");
            if (filmes.Count() == 2) throw new CopaFilmesAPIValidationException("Não selecionado quantidade mínima de time para iniciar o campeonato.");
            var _filmes = filmes.Select(i => i).OrderBy(f => f.Titulo).ToList();
            return _filmes.MontarChaveamento();
        }

        /// <summary>
        /// Monta o chaveamento dos jogos para dar sequência nas partidas
        /// </summary>
        /// <param name="filmes">Lista de filmes para montar a chave dos jogos</param>
        /// <returns>Lista contendo as chaves para execução dos jogos</returns>
        public static IEnumerable<Filme>[] MontarChaveamento(this IEnumerable<Filme> filmes)
        {
            var copiaFilmes = filmes.Select(i => i).ToList();
            var chave = new List<IEnumerable<Filme>>();
            while (copiaFilmes.Count() > 0)
            {
                chave.AdicionarLista(copiaFilmes[0], copiaFilmes[copiaFilmes.Count() - 1]);
                chave.ForEach(l => l.ToList().ForEach(f => { if (copiaFilmes.Contains(f)) { copiaFilmes.Remove(f); } }));
            }
            return chave.ToArray();
        }

        /// <summary>
        /// Adiciona nova lista de filme na lista principal
        /// </summary>
        /// <param name="lista">Lista principal que armazena as chaves da competição</param>
        /// <param name="filmes">Lista de time que será incluído na listagem de chaves</param>
        public static void AdicionarLista(this List<IEnumerable<Filme>> lista, params Filme[] filmes)
        {
            var listaFilmes = new List<Filme>();
            listaFilmes.AddRange(filmes);
            lista.Add(listaFilmes);
        }

        /// <summary>
        /// Executa as partidas do campeonato até restar dois Filmes para a final do campeonato
        /// </summary>
        /// <param name="filmes">Lista de filmes para executar a partida do campeonato</param>
        /// <returns>Retorna a listagem de filme que foram vencedoras da rodada</returns>
        public static IEnumerable<Filme> ExecutarEliminatorias(this IEnumerable<Filme>[] filmes)
        {
            var filmesVencedores = filmes.Select(i => i.ExecutaPartida());
            if (filmesVencedores.Count() > 2)
                filmesVencedores = filmesVencedores.MontarChaveamento().ExecutarEliminatorias();
            return filmesVencedores;
        }

        /// <summary>
        /// Executa a partida para verificar o filme vencedor
        /// </summary>
        /// <param name="filmes">Lista de filme que disputarão a partida</param>
        /// <returns>Retorna o filme vencedor</returns>
        public static Filme ExecutaPartida(this IEnumerable<Filme> filmes)
        {
            return filmes.ExecutaPartidaFinal().ToArray()[0];
        }

        /// <summary>
        /// Executa partida final do campeonato
        /// </summary>
        /// <param name="filmes">Lista final de times que irão disputar a partida final</param>
        /// <returns>Retorna o campeão em primeiro lugar e o vice campeão na segunda posição</returns>
        public static IEnumerable<Filme> ExecutaPartidaFinal(this IEnumerable<Filme> filmes)
        {
            var lista = filmes.Select(i => i).ToList();
            lista.Sort();
            return lista;
        }
    }
}
