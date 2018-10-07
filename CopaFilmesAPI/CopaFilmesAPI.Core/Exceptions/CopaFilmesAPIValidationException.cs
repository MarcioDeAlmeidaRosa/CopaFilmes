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
    public class CopaFilmesAPIValidationException: Exception
    {
        /// <summary>
        /// Armazena os erros que serão lançados
        /// </summary>
        private readonly IEnumerable<string> _errors;

        /// <summary>
        /// Retornar os erros que serão lançados
        /// </summary>
        public IEnumerable<string> Errors => _errors.ToList();

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="message">Mensagem de erro</param>
        public CopaFilmesAPIValidationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        /// <param name="errors">Lista de mensagem de erro</param>
        public CopaFilmesAPIValidationException(IEnumerable<string> errors) : base(errors.AsErrorMessage())
        {
            _errors = errors;
        }

        /// <summary>
        /// Inicializa uma instância da classe com os erros de validações
        /// </summary>
        /// <param name="validationFailures"></param>
        public CopaFilmesAPIValidationException(IEnumerable<ValidationFailure> validationFailures) : this(validationFailures.AsErrorsList())
        {
        }
    }
}
