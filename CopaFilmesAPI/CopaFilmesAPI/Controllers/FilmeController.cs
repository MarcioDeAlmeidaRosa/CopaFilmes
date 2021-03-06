﻿using System;
using System.Net;
using System.Net.Http;
using CopaFilmesAPI.Actions;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Controllers
{
    /// <summary>
    /// Disponibiliza funcionalidades de filme
    /// </summary>
    public class FilmeController : BaseController
    {
        /// <summary>
        /// Variável para armazenar a instância da ação
        /// </summary>
        private readonly FilmeActions _actions;

        /// <summary>
        /// Inicializa uma instância da classe
        /// </summary>
        public FilmeController()
        {
            _actions = new FilmeActions();
        }

        /// <summary>
        /// Fornece lista de Filme para o cliente
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _actions.Listar());
            }
            catch (Exception ex)
            {
                return InternalErro(ex);
            }
        }
    }
}
