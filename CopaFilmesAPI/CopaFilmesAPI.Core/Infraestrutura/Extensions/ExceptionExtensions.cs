using System;
using System.Collections.Generic;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para as exceptions
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Converte uma lista de mensagem em um núnico registro
        /// </summary>
        /// <param name="values">Lista de erro</param>
        /// <returns>Mensagem única de todos os erros</returns>
        public static string AsErrorMessage(this IEnumerable<string> values)
        {
            return string.Join(Environment.NewLine, values);
        }
    }
}
