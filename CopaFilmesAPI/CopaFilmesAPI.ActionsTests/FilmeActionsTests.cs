using System.Linq;
using CopaFilmesAPI.Actions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmesAPI.ActionsTests
{
    [TestClass()]
    public class FilmeActionsTests
    {
        /// <summary>
        /// Valida a resposta da consulta de filmes, ela não pode ser nula
        /// </summary>
        [TestMethod()]
        public async Task ValidaRetornoNaoNullo()
        {
            var action = new FilmeActions();
            var resultado = await action.Listar();
            Assert.AreNotEqual(resultado, null);
        }

        /// <summary>
        /// Valida quantidade de filmes retornados pela consulta
        /// </summary>
        [TestMethod()]
        public async Task ValidaQuantidadeRegistroRetornados()
        {
            var action = new FilmeActions();
            var resultado = await action.Listar();
            Assert.AreEqual(resultado.ToList().Count, 16);
        }

        /// <summary>
        /// Valida nota do primeiro filme da lista
        /// </summary>
        [TestMethod()]
        public async Task ValidaNotaPrimeiroRegistroLista()
        {
            var action = new FilmeActions();
            var resultado = await action.Listar();
            Assert.AreEqual(resultado.ToList()[0].Nota, 8.5, 0.0001);
        }

        /// <summary>
        /// Valida nota do ultimo filme da lista
        /// </summary>
        [TestMethod()]
        public async Task ValidaNotaUltimoRegistroLista()
        {
            var action = new FilmeActions();
            var resultado = await action.Listar();
            Assert.AreEqual(resultado.ToList()[resultado.Count() - 1].Nota, 7.8, 0.0001);
        }
    }
}
