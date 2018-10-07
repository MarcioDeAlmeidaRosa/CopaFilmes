using RestSharp;
using System.Linq;
using System.Collections;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para o RestSharp
    /// </summary>
    public static class RestSharpExtensions
    {
        /// <summary>
        /// Adicona parâmetro em um objeto Rest criado
        /// </summary>
        /// <param name="restRequest">Objeto que receberá o parâmetro</param>
        /// <param name="entryFilters">objeto que será adicionado ao objeto rest</param>
        /// <returns></returns>
        public static IRestRequest AddParameters(this IRestRequest restRequest, object entryFilters)
        {
            if (entryFilters == null)
            {
                return restRequest;
            }

            var properties = entryFilters
                .GetType()
                .GetProperties()
                .ToList()
                .Select(property => new
                {
                    Name = property.Name.ToFirstCharLowerCase(),
                    Value = property.GetValue(entryFilters, null)
                })
                .Where(property => property.Value != null)
                .ToList();

            properties
                .ForEach(property => restRequest.AddParameter(property.Name, property.Value.ToParameterValue()));

            return restRequest;
        }

        /// <summary>
        /// Converte objeto em string
        /// </summary>
        /// <param name="objectValue">objeto se será recuperado seu valor</param>
        /// <returns>String recuperada do objeto</returns>
        public static string ToParameterValue(this object objectValue)
        {
            switch (objectValue)
            {
                case null:
                    return string.Empty;
                case string stringValue:
                    return stringValue;
            }

            if (!(objectValue is IEnumerable enumerable))
            {
                return objectValue.ToString();
            }

            var itens = enumerable
                .Cast<object>()
                .Where(item => item != null)
                .Select(item => item.ToString());

            return string.Join(",", itens);
        }
    }
}
