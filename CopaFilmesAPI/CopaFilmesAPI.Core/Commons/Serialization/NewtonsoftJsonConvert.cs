using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CopaFilmesAPI.Core.Commons.Serialization
{
    /// <summary>
    /// Responsável por executar converções de JSON
    /// </summary>
    public static class NewtonsoftJsonConvert
    {
        /// <summary>
        /// Armazena configurações para executar as conversões
        /// </summary>
        public static readonly JsonSerializerSettings DefaultSettings;

        /// <summary>
        /// Configura os parâmetros para conversão em JSON
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
        /// Transforma objeto em um JSON
        /// </summary>
        /// <param name="objeto">instância de objeto para converter em JSON</param>
        /// <returns>String JSON representando o objeto enviado via parâmetro <paramref name="objeto"/></returns>
        public static string SerializeToJSON(this object objeto)
        {
            return JsonConvert.SerializeObject(objeto, DefaultSettings);
        }

        /// <summary>
        /// Transforma JSON no Objeto do tipo <typeparamref name="TObject"/> solicitado
        /// </summary>
        /// <typeparam name="TObject">Tipo para a conversão do objeto</typeparam>
        /// <param name="jsonText">Conteúdo JSON que será usado para converter no objeto solicitado</param>
        /// <returns>Objeto convertido do tipo <typeparamref name="TObject"/></returns>
        public static TObject DeserializeJSON<TObject>(this string jsonText)
        {
            return JsonConvert.DeserializeObject<TObject>(jsonText, DefaultSettings);
        }
    }
}
