using System;
using System.Linq;
using System.Collections.Generic;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Responsável por auxiliar na execução das rodadas
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Responsável por definir o primeiro confronto dos registros escolhidos
        /// </summary>
        /// <typeparam name="TSource">Define o tipo que será permitido esta função extra</typeparam>
        /// <typeparam name="TKey">Define o tipo que será utilizado na ordenação</typeparam>
        /// <param name="list">Listagem que será considerada para chaveamento</param>
        /// <param name="orderBy">Função que será utilizada para ordenar os registros antes de montar a chave</param>
        /// <returns>Lista contendo chaveamento entre os registros</returns>
        public static IEnumerable<TSource>[] MontarChaveamento<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> orderBy)
        {
            var _list = list.Select(i => i).OrderBy(orderBy).ToList();
            var result = new List<IEnumerable<TSource>>();
            while (_list.Count() > 0)
            {
                if (_list.Count() > 1)
                {
                    result.Add(new List<TSource>() { _list[0], _list[_list.Count() - 1] });
                    _list.Remove(_list[_list.Count() - 1]);
                }
                else
                    result.Add(new List<TSource>() { _list[0] });
                _list.Remove(_list[0]);
            }
            return result.ToArray();
        }
    }
}
