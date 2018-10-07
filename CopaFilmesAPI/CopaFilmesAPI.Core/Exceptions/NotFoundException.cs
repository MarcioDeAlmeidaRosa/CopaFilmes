using System;

namespace CopaFilmesAPI.Core.Exceptions
{
    /// <summary>
    /// Representa erros ocorridos durante a execução da aplicação
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Armazena os erros que serão lançados
        /// </summary>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Armazena os erros que serão lançados
        /// </summary>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="innerException">Erro vinculado</param>
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
