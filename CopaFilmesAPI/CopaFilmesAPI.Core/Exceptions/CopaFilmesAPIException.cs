using System;
using System.Linq;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Infraestrutura.Extensions;

namespace CopaFilmesAPI.Core.Exceptions
{
    /// <summary>
    /// Representa erros ocorridos durante a execução da aplicação
    /// </summary>
    public class CopaFilmesAPIException : Exception
    {
        /// <summary>
        /// Armazena os erros que serão lançados
        /// </summary>
        private readonly IEnumerable<string> _erros;

        /// <summary>
        /// Retornar os erros que serão lançados
        /// </summary>
        public IEnumerable<string> Erros => _erros.ToList();

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="mensagem">Mensagem de erro</param>
        public CopaFilmesAPIException(string mensagem) : base(mensagem)
        {
            _erros = new List<string>() { mensagem };
        }

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="erros">Mensagem de erro</param>
        public CopaFilmesAPIException(IEnumerable<string> erros) : base(erros.AsErrorMessage())
        {
            _erros = erros;
        }
    }
}
