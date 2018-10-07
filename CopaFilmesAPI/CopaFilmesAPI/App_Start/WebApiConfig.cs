using Newtonsoft.Json;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace CopaFilmesAPI
{
    /// <summary>
    /// Configuração para start da aplicação
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Responsável por registrar as rotas ao iniciar a aplicação
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //setando não retorno de propriedade null
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //configura o padrão para a serialização das classes do projeto
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver() { };
            //configurando ignore data anannotation nas propriedades
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
