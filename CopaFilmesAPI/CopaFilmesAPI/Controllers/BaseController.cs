using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Collections.Generic;
using CopaFilmesAPI.Core.Exceptions;

namespace CopaFilmesAPI.Controllers
{
    /// <summary>
    /// Responsável por disponibilizar comportamentos genéricos para as demais classes controle da API
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
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
                    Erros = new[] {((NotFoundException)exception).Message},
                    HttpStatusCode = HttpStatusCode.NotFound
                }
            },
            {
                typeof(CopaFilmesAPIValidationException), exception => new
                {
                    ((CopaFilmesAPIValidationException)exception).Erros,
                    HttpStatusCode = HttpStatusCode.BadRequest
                }
            },
            {
                typeof(CopaFilmesAPIException), exception => new
                {
                    ((CopaFilmesAPIException)exception).Erros,
                    HttpStatusCode = HttpStatusCode.BadRequest
                }
            }
        };

        /// <summary>
        /// Tratamento de erro genérico para os controles da API
        /// </summary>
        /// <param name="ex">Exception gerado pela aplicação</param>
        /// <returns>Retorna erro para o cliente</returns>
        protected HttpResponseMessage InternalErro(Exception ex)
        {
            var typeException = ex.GetType();
            if (!_mappedException.ContainsKey(typeException)) return Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            var mappedException = _mappedException[typeException](ex);
            return Request.CreateErrorResponse((HttpStatusCode)mappedException.HttpStatusCode, new HttpError(JsonConvert.SerializeObject(mappedException.Erros)));
        }
    }
}
