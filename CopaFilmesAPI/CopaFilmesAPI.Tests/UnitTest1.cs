using System;
using CopaFilmesAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmesAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void IniciaExecucaoDosTeste()
        {
        }

        [TestMethod]
        public void DeveValidarFilmeComMaiorNota()
        {
            var filmeComMenorNota = new Filme()
            {
                ID = "123",
                Ano = 2018,
                Nota = 5.5,
                Titulo = "Filme com menor nota"
            };

            var filmeComMaiorNota = new Filme()
            {
                ID = "159",
                Ano = 2017,
                Nota = 8.5,
                Titulo = "Filme com maior nota"
            };
            var valorComparacao = filmeComMenorNota.CompareTo(filmeComMaiorNota);
            Assert.AreEqual(-1, valorComparacao);
        }

        [TestCleanup]
        public void FinalizaExecucaoDosTeste()
        {
        }
    }
}
