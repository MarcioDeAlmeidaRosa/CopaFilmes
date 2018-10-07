using System;
using CopaFilmesAPI.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CopaFilmesAPI.DAO
{
    /// <summary>
    /// Responsável por definir o contrato de um DAO da aplicação
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAO<T> where T: ModelBase
    {
        /// <summary>
        /// Responsável por recuperar <typeparamref name="T"/> pelo <paramref name="id"/>
        /// </summary>
        /// <param name="filter">Filtro para a entidade</param>
        /// <returns>Entidade <typeparamref name="T"/> localizada pelo filtro informado</returns>
        /// <exception cref="ArgumentException"> Exceção lançada quando o <paramref name="filter"/> for nulo</exception>
        Task<T> BuscarPorId(T filter);

        /// <summary>
        /// Responsável por recuperar lista de <typeparamref name="T"/>
        /// </summary>
        /// <returns>Lista da entidade <typeparamref name="T"/> localizada</returns>
        Task<IEnumerable<T>> Listar();
    }
}
