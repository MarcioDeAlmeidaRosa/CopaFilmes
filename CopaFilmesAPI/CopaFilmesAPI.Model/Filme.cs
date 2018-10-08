using System;

namespace CopaFilmesAPI.Model
{
    /// <summary>
    /// Responsável por definir as propriedades de um filme
    /// </summary>
    public class Filme : ModelBase, IComparable
    {
        /// <summary>
        /// Titulo do filme
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Ano de lançamento do filme
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Nota atribuída pelo público
        /// </summary>
        public double Nota { get; set; }

        /// <summary>
        /// Método para orientar a ordenação de um filme
        /// </summary>
        /// <param name="obj">Objeto que será comparado com o filme em questão</param>
        /// <returns>Retorna negativo quando o filme corrente for menor que o objeto comparado, 0 quando for igual, e positivo quando o objeto comparado for menor que o filme atual</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Filme outroObj))
                return -1;
            var result = Nota.CompareTo(outroObj.Nota);
            if (result == 0)
                result = Titulo.CompareTo(outroObj.Titulo);
            return result;
        }
    }
}
