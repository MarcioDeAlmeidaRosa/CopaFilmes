using System;

namespace CopaFilmesAPI.Model
{
    public class Filme: IComparable
    {
        public string ID { get; set; }

        public string Titulo { get; set; }

        public int Ano { get; set; }

        public double Nota { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Filme outroObj))
                return -1;
            return Nota.CompareTo(outroObj.Nota);
        }
    }
}
