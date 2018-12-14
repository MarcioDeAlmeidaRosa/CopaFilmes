using System;
using System.Linq;
using FluentValidation.Results;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Infraestrutura.Extensions;

namespace CopaFilmesAPI.Core.Exceptions
{
    /// <summary>
    /// Representa erros ocorridos durante a execução da aplicação
    /// </summary>
    public class CopaFilmesAPIValidationException : Exception
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
        public CopaFilmesAPIValidationException(string mensagem) : base(mensagem)
        {
            _erros = new List<string>() { mensagem };
        }

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="erros">Mensagens de erro</param>
        public CopaFilmesAPIValidationException(IEnumerable<string> erros) : base(erros.AsErrorMessage())
        {
            _erros = erros;
        }

        /// <summary>
        /// Inicializa uma instância da classe com os erros de validações
        /// </summary>
        /// <param name="falhasValicacao">Mensagens de erro</param>
        public CopaFilmesAPIValidationException(IEnumerable<ValidationFailure> falhasValicacao) : this(falhasValicacao.AsErrorsList())
        {
        }
    }
}
