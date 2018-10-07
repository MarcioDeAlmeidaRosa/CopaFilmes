using System.Linq;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Responses;
using CopaFilmesAPI.Core.Infraestrutura.Serialization;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para os JSON
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Recupera erros de uma resposta serializada
        /// </summary>
        /// <param name="errorsJsonContent">JSON contendo o objeto com a lista de erro</param>
        /// <returns></returns>
        public static IEnumerable<string> ExtractErrors(this string errorsJsonContent)
        {
            if (string.IsNullOrWhiteSpace(errorsJsonContent))
            {
                return new List<string>();
            }

            var response = errorsJsonContent.DeserializeJSON<CopaFilmesAPIErroResponse>();

            if (response?.Erros != null && response.Erros.Any())
            {
                return response.Erros;
            }

            return new List<string>();
        }
    }
}
