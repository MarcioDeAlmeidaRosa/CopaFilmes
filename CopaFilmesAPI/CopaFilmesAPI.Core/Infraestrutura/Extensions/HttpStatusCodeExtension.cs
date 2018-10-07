using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para os códigos de status
    /// </summary>
    public static class HttpStatusCodeExtension
    {
        /// <summary>
        /// Verifica se o código esta contido em uma lista
        /// </summary>
        /// <param name="statusCode">Código que será validado na lista</param>
        /// <param name="status">Lista para verificar se existe o código solicitado</param>
        /// <returns>True se existir, ou False se não existir</returns>
        public static bool In(this HttpStatusCode statusCode, IEnumerable<HttpStatusCode> status)
        {
            return status.Any(s => s == statusCode);
        }
    }
}
