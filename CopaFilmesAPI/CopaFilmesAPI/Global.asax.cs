using System.Web;
using System.Web.Http;

namespace CopaFilmesAPI
{
    /// <summary>
    /// Responsável por execuções nos passo de execução da aplicação
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Executando ao iniciar a API, carrega comportamentos fundamentais para início da API
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
