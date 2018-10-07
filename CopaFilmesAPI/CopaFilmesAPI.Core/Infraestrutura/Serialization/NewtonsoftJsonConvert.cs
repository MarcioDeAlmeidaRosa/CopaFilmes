using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CopaFilmesAPI.Core.Infraestrutura.Serialization
{
    /// <summary>
    /// Extensão para auxiliar nos trabalhos de conversão de tipos
    /// </summary>
    public static class NewtonsoftJsonConvert
    {
        public static readonly JsonSerializerSettings DefaultSettings;

        /// <summary>
        /// Configura configuração para serialização/deserialização
        /// </summary>
        static NewtonsoftJsonConvert()
        {
            DefaultSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None
            };

            DefaultSettings.Converters
                .Add(new StringEnumConverter
                {
                    AllowIntegerValues = true,
                    CamelCaseText = true
                });
        }

        /// <summary>
        /// Transforma <paramref name="objectInstance"/> em uma string JSon
        /// </summary>
        /// <param name="objectInstance">Objeto que deseja transformar em JSon</param>
        /// <returns>Conteúdo string do objeto enviado</returns>
        public static string SerializeToJSON(this object objectInstance)
        {
            return JsonConvert.SerializeObject(objectInstance, DefaultSettings);
        }

        /// <summary>
        /// Transforma <paramref name="jsonTexto"/> em <typeparamref name="TObject"/>
        /// </summary>
        /// <typeparam name="TObject">Tipo que será usado na conversão da string</typeparam>
        /// <param name="jsonTexto">Conteúdo para ser convertido</param>
        /// <returns><typeparamref name="TObject"/> contendo os valores de <paramref name="jsonTexto"/></returns>
        public static TObject DeserializeJSON<TObject>(this string jsonTexto)
        {
            return JsonConvert.DeserializeObject<TObject>(jsonTexto, DefaultSettings);
        }
    }
}
