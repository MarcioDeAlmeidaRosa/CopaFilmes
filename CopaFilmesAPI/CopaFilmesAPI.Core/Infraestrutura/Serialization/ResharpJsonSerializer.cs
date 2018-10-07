using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp.Serializers;

namespace CopaFilmesAPI.Core.Infraestrutura.Serialization
{
    /// <summary>
    /// Responsável por Transformar objeto enviado ao RestSharp em JSON
    /// </summary>
    public class ResharpJsonSerializer : ISerializer
    {
        /// <summary>
        /// Objeto contendo as configurações para a serialização do objeto
        /// </summary>
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        /// <summary>
        /// Armazena o formato de data para a conversão
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Armazena o elemento raiz para a conversão
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Armazena o namespace para a conversão
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Armazena o contentType para a conversão
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Responsável por expor a configuração usada para serialização
        /// </summary>
        protected Newtonsoft.Json.JsonSerializer Serializer => serializer;

        /// <summary>
        /// Contrutor onde são atribuído as configurações
        /// </summary>
        public ResharpJsonSerializer()
        {
            ContentType = "application/json";

            serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None
            };

            serializer.Converters
                .Add(new StringEnumConverter
                {
                    AllowIntegerValues = true,
                    CamelCaseText = true
                });
        }

        /// <summary>
        /// Responsável por executar a serialização do objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';
                    Serializer.Serialize(jsonTextWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }
    }
}
