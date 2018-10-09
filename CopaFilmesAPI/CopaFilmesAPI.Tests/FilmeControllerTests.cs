using CopaFilmesAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Tests
{
    [TestClass()]
    public class FilmeControllerTests
    {
        /// Valida a resposta da consulta de filmes, ela não pode ser nula
        /// </summary>
        [TestMethod()]
        public async Task ValidaRetornoNaoNullo()
        {
            FilmeController ctrl = new FilmeController();
            var resultado = await ctrl.Get();
            Assert.AreNotEqual(resultado, null);
        }

        /// <summary>
        /// Valida quantidade de filmes retornados pela consulta
        /// </summary>
        [TestMethod()]
        public async Task ValidaQuantidadeRegistroRetornados()
        {
            FilmeController ctrl = new FilmeController();
            var resultado = await ctrl.Get();
            Assert.AreEqual(resultado.ToList().Count, 16);
        }

        /// <summary>
        /// Valida nota do primeiro filme da lista
        /// </summary>
        [TestMethod()]
        public async Task ValidaNotaPrimeiroRegistroLista()
        {
            FilmeController ctrl = new FilmeController();
            var resultado = await ctrl.Get();
            Assert.AreEqual(resultado.ToList()[0].Nota, 8.5, 0.0001);
        }

        /// <summary>
        /// Valida nota do ultimo filme da lista
        /// </summary>
        [TestMethod()]
        public async Task ValidaNotaUltimoRegistroLista()
        {
            FilmeController ctrl = new FilmeController();
            var resultado = await ctrl.Get();
            Assert.AreEqual(resultado.ToList()[resultado.Count() - 1].Nota, 7.8, 0.0001);
        }
    }
}
