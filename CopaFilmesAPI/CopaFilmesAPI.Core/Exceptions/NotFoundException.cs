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
        public NotFoundException(string mensagem) : base(mensagem)
        {
        }

        /// <summary>
        /// Armazena os erros que serão lançados
        /// </summary>
        /// <param name="mensagem">Mensagem de erro</param>
        /// <param name="excecaoInterna">Erro original que gerou a exception</param>
        public NotFoundException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
        {
        }
    }
}
