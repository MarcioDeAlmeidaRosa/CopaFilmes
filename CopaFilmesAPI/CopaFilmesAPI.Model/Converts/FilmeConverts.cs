using System;
using System.Linq;
using System.Collections.Generic;

namespace CopaFilmesAPI.Model.Converts
{
    /// <summary>
    /// Responsável por auxiliar na execução das rodadas
    /// </summary>
    public static class FilmeConverts
    {
        /// <summary>
        /// Responsável por definir o primeiro confronto dos registros escolhidos
        /// </summary>
        /// <typeparam name="TSource">Define o tipo que será permitido esta função extra</typeparam>
        /// <typeparam name="TKey">Define o tipo que será utilizado na ordenação</typeparam>
        /// <param name="list">Listagem que será considerada para chaveamento</param>
        /// <param name="orderBy">Função que será utilizada para ordenar os registros antes de montar a chave</param>
        /// <returns>Lista contendo chaveamento entre os registros</returns>
        public static IEnumerable<Filme>[] MontarChaveamentoInicial(this IEnumerable<Filme> list)
        {
            var _list = list.Select(i => i).OrderBy(f => f.Titulo).ToList();
            var result = new List<IEnumerable<Filme>>();
            while (_list.Count() > 0)
            {
                if (_list.Count() > 1)
                {
                    result.Add(new List<Filme>() { _list[0], _list[_list.Count() - 1] });
                    _list.Remove(_list[_list.Count() - 1]);
                }
                else
                    result.Add(new List<Filme>() { _list[0] });
                _list.Remove(_list[0]);
            }
            return result.ToArray();
        }


        public static IEnumerable<Filme> ExecutarEliminatorias(this IEnumerable<Filme>[] list)
        {
            var _list = list.Select(i => i.ExecutaPartida());

            if (_list.Count()>2)
                _list = _list.MontarChaveamento().ExecutarEliminatorias();

            return _list;
        }

        public static Filme ExecutaPartida(this IEnumerable<Filme> list)
        {
            var lista = list.Select(i => i).ToList();
            lista.Sort();
            return lista[0];
        }

        public static IEnumerable<Filme>[] MontarChaveamento(this IEnumerable<Filme> list)
        {
            var _list = list.Select(i => i).ToList();
            var result = new List<IEnumerable<Filme>>();
            while (_list.Count() > 0)
            {
                if (_list.Count() > 1)
                {
                    result.Add(new List<Filme>() { _list[0], _list[_list.Count() - 1] });
                    _list.Remove(_list[_list.Count() - 1]);
                }
                else
                    result.Add(new List<Filme>() { _list[0] });
                _list.Remove(_list[0]);
            }
            return result.ToArray();
        }

        public static IEnumerable<Filme> ExecutaPartidaFinal(this IEnumerable<Filme> list)
        {
            var lista = list.Select(i => i).ToList();
            lista.Sort();
            return lista;
        }
    }
}
