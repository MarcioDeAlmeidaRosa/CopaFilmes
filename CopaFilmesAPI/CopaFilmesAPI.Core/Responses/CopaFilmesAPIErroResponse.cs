using System.Collections.Generic;

namespace CopaFilmesAPI.Core.Responses
{
    /// <summary>
    /// Representa a resposta de erro no processamento
    /// </summary>
    public class CopaFilmesAPIErroResponse
    {
        /// <summary>
        /// Lista de erros da aplicação
        /// </summary>
        public IEnumerable<string> Erros { get; set; }
    }
}
