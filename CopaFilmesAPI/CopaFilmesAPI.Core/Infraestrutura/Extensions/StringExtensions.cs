using System.Globalization;

namespace CopaFilmesAPI.Core.Infraestrutura.Extensions
{
    /// <summary>
    /// Representa tratamentos especializados para string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Transforma o primeiro caracter de uma palavra em maiúsculo
        /// </summary>
        /// <param name="stringValue">valor que será verificado e transformado</param>
        /// <returns></returns>
        public static string ToFirstCharLowerCase(this string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return stringValue;
            }

            return stringValue.Length == 1
                ? stringValue.ToLower()
                : stringValue[0].ToString(CultureInfo.InvariantCulture).ToLower() + stringValue.Substring(1);
        }
    }
}
