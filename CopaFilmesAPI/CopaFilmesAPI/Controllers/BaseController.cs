using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Exceptions;

namespace CopaFilmesAPI.Controllers
{
    /// <summary>
    /// Responsável por disponibilizar comportamentos genéricos para as demais classes controle da API
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// Lista de possíveis exceptions retornada no processamento da aplicação
        /// </summary>
        private readonly IDictionary<Type, Func<Exception, dynamic>> _mappedException = new Dictionary<Type, Func<Exception, dynamic>>
        {
            {
                typeof(NotFoundException), exception => new
                {
                    Errors = new[] {((NotFoundException)exception).Message},
                    HttpStatusCode = HttpStatusCode.NotFound
                }
            },
            {
                typeof(CopaFilmesAPIValidationException), exception => new
                {
                    ((CopaFilmesAPIException)exception).Errors,
                    HttpStatusCode = HttpStatusCode.BadRequest
                }
            },
            {
                typeof(CopaFilmesAPIException), exception => new
                {
                    ((CopaFilmesAPIException)exception).Errors,
                    HttpStatusCode = HttpStatusCode.BadRequest
                }
            }
        };

        /// <summary>
        /// Tratamento de erro genérico para os controles da API
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected HttpResponseMessage InternalErro(Exception ex)
        {
            var typeException = ex.GetType();
            if (!_mappedException.ContainsKey(typeException)) return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError("Erro interno do servidor"));
            var mappedException = _mappedException[typeException](ex);
            return Request.CreateResponse((HttpStatusCode)mappedException.HttpStatusCode, new HttpError(mappedException.Errors));
        }
    }
}
