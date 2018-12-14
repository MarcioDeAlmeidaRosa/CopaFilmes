using System;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmesAPI.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmesAPI.Actions.Tests
{
    [TestClass()]
    public class PartidaActionTests
    {
        /// <summary>
        /// Valida quantidade de filmes retornado ao processar o campeonato
        /// </summary>
        /// <returns></returns>
        [TestMethod()]
        public async Task TestandoCampeonatoConformeRegraPDF()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[8] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" });
            Assert.AreEqual(campeoes.Count(), 2);
        }

        /// <summary>
        /// Valida nota do primeiro colocado
        /// </summary>
        /// <returns></returns>
        [TestMethod()]
        public async Task TestandoCampeonatoConformeRegraPDFFilmeCampeao()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[8] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" });
            Assert.AreEqual(campeoes.ToList()[0].Nota, 8.8, 0.0001);
        }

        /// <summary>
        /// Valida nota do segundo colocado
        /// </summary>
        /// <returns></returns>
        [TestMethod()]
        public async Task TestandoCampeonatoConformeRegraPDFFilmeViceCampeao()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[8] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" });
            Assert.AreEqual(campeoes.ToList()[1].Nota, 8.5, 0.0001);
        }

        /// <summary>
        /// Verificar acesso a posição que não existe do array
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task VerificaArgumentOutOfRangeException()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[8] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" });
            var nota = campeoes.ToList()[3].Nota;
        }

        /// <summary>
        /// Verificar execução de Converts com referência nula
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task VerificaMontarChaveamentoInicialArgumentNullException()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(null);
            var nota = campeoes.ToList()[3].Nota;
        }

        /// <summary>
        /// Verificar execução de Converts com lista vazia
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(NotFoundException))]
        public async Task VerificaMontarChaveamentoInicialNotFoundException()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[1] { "AA3606756" });
            var nota = campeoes.ToList()[3].Nota;
        }

        /// <summary>
        /// Verificar execução com quantidade impar na lista
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CopaFilmesAPIValidationException))]
        public async Task VerificaMontarChaveamentoInicialCopaFilmesAPIValidationException()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[1] { "tt3606756" });
            var nota = campeoes.ToList()[3].Nota;
        }

        /// <summary>
        /// Verificar execução com quantidade mínima não atingida de filme
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CopaFilmesAPIValidationException))]
        public async Task VerificaMontarChaveamentoInicialComDoisFilmesCopaFilmesAPIValidationException()
        {
            var action = new PartidaAction();
            var campeoes = await action.ProcessaCampeonato(new string[2] { "tt3606756", "tt4881806" });
            var nota = campeoes.ToList()[3].Nota;
        }
    }
}