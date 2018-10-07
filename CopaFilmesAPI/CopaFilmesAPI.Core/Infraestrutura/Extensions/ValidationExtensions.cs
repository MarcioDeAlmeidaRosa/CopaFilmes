using System.Linq;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para validações
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Converte uma lista de validações para uma lista de string
        /// </summary>
        /// <param name="failures">lista de validações para conversão</param>
        /// <returns>Lista das crícitas em string</returns>
        public static IList<string> AsErrorsList(this IEnumerable<ValidationFailure> failures)
        {
            return failures
                .Select(validationFailure => validationFailure.ErrorMessage)
                .ToList();
        }
    }
}
