using System;
using System.Linq;
using System.Collections.Generic;
using CopaFilmesAPI.Model.Converts;
using CopaFilmesAPI.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmesAPI.Model.Tests
{
    /// <summary>
    /// Classe de teste responsável por testar o metodo de comparação da classe de filme
    /// </summary>
    [TestClass()]
    public class FilmeTests
    {
        /// <summary>
        /// Variável para auxiliar os testes de ordenação
        /// </summary>
        private List<Filme> listaFilme;

        /// <summary>
        /// Inicializa itens na lista de filme para testar a ordenação
        /// </summary>
        [TestInitialize()]
        public void IniciaExecucaoDosTeste()
        {
            listaFilme = new List<Filme>()
            {
                new Filme()
                {
                    ID = "tt3606756",
                    Ano = 2018,
                    Nota = 8.5  ,
                    Titulo = "Os Incríveis 2"
                },
                new Filme()
                {
                    ID = "tt4881806",
                    Ano = 2018,
                    Nota = 6.7,
                    Titulo = "Jurassic World: Reino Ameaçado"
                },
                new Filme()
                {
                    ID = "tt5164214",
                    Ano = 2018,
                    Nota = 6.3,
                    Titulo = "Oito Mulheres e um Segredo"
                },
                new Filme()
                {
                    ID = "tt2364214",
                    Ano = 2018,
                    Nota = 6.3,
                    Titulo = "Oito Mulheres e um Segredo_"
                }
            };
        }

        /// <summary>
        /// Verificar maior nota depois de ordernar
        /// </summary>
        [TestMethod()]
        public void ValidaMaiorNota()
        {
            listaFilme.Sort();
            Assert.AreEqual(8.5, listaFilme[0].Nota, 0.0001);
        }

        /// <summary>
        /// Verificar a segunda maior nota
        /// </summary>
        [TestMethod()]
        public void ValidaSegundaMaiorNota()
        {
            listaFilme.Sort();
            Assert.AreEqual(6.7, listaFilme[1].Nota, 0.0001);
        }

        /// <summary>
        /// Verificar terceira maior nota usando o critério de desempate o título do filme
        /// </summary>
        [TestMethod()]
        public void VerificaTerceiraMaiorNotaValidandoDesempate()
        {
            listaFilme.Sort();
            Assert.AreEqual("tt5164214", listaFilme[2].ID);
        }

        /// <summary>
        /// Verificar menor nota usando o critério de desempate o título do filme
        /// </summary>
        [TestMethod()]
        public void VerificaUltimaNotaValidandoDesempate()
        {
            listaFilme.Sort();
            Assert.AreEqual("tt2364214", listaFilme[listaFilme.Count - 1].ID);
        }

        /// <summary>
        /// Verificar titulo do filme com menor nota
        /// </summary>
        [TestMethod()]
        public void VerificaTituloUltimaFilme()
        {
            listaFilme.Sort();
            Assert.AreEqual("Oito Mulheres e um Segredo_", listaFilme[listaFilme.Count - 1].Titulo);
        }

        /// <summary>
        /// Verificar ano do ultimo registro da lista de filme
        /// </summary>
        [TestMethod()]
        public void VerificaAnoDoPrimeiroFilme()
        {
            listaFilme.Sort();
            Assert.AreEqual(2018, listaFilme[listaFilme.Count - 1].Ano);
        }

        /// <summary>
        /// Verificar acesso a posição que não existe do array
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerificaArgumentOutOfRangeException()
        {
            listaFilme.Sort();
            Console.WriteLine(listaFilme);
            var teste = listaFilme[listaFilme.Count];
        }

        /// <summary>
        /// Verificar execução de Converts com referência nula
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerificaMontarChaveamentoInicialArgumentNullException()
        {
            IEnumerable<Filme> lista = null;
            var teste = lista.MontarChaveamentoInicial();
        }

        /// <summary>
        /// Verificar execução de Converts com lista vazia
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(NotFoundException))]
        public void VerificaMontarChaveamentoInicialNotFoundException()
        {
            IEnumerable<Filme> lista = new List<Filme>();
            var teste = lista.MontarChaveamentoInicial();
        }

        /// <summary>
        /// Verificar execução com quantidade impar na lista
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(CopaFilmesAPIValidationException))]
        public void VerificaMontarChaveamentoInicialCopaFilmesAPIValidationException()
        {
            IEnumerable<Filme> lista = new List<Filme>() { listaFilme[0], listaFilme[1], listaFilme[3] };
            var teste = lista.MontarChaveamentoInicial();
        }

        /// <summary>
        /// Verificar execução MontarChaveamentoInicial
        /// </summary>
        [TestMethod()]
        public void VerificaMontarChaveamentoInicialComDuasChaves()
        {
            IEnumerable<Filme> lista = new List<Filme>() { listaFilme[0], listaFilme[1], listaFilme[2], listaFilme[3] };
            var chaves = lista.MontarChaveamentoInicial();
            Assert.AreEqual(chaves.Count(), 2);
        }

        /// <summary>
        /// Verificar execução MontarChaveamento
        /// </summary>
        [TestMethod()]
        public void VerificaMontarChaveamento()
        {
            IEnumerable<Filme> lista = new List<Filme>() { listaFilme[0], listaFilme[1], listaFilme[2], listaFilme[3] };
            var chaves = lista.MontarChaveamento();
            Assert.AreEqual(chaves.Count(), 2);
        }

        /// <summary>
        /// Verificar a inclusão de novas chaves na lista
        /// </summary>
        [TestMethod()]
        public void VerificaAdicionarLista()
        {
            List<IEnumerable<Filme>> lista = new List<IEnumerable<Filme>>();
            lista.AdicionarLista(listaFilme[0], listaFilme[1]);
            lista.AdicionarLista(listaFilme[2], listaFilme[3]);
            Assert.AreEqual(lista.Count(), 2);
        }

        /// <summary>
        /// Verifica eliminatória dos times
        /// </summary>
        [TestMethod()]
        public void VerificaExecutarEliminatorias()
        {
            List<Filme>[] lista = new List<Filme>[2];
            lista[0] = new List<Filme>() { listaFilme[0], listaFilme[1] };
            lista[1] = new List<Filme>() { listaFilme[2], listaFilme[3] };
            var filmes = lista.ExecutarEliminatorias();
            Assert.AreEqual(filmes.Count(), 2);
        }

        /// <summary>
        /// Verifica ExecutaPartida
        /// </summary>
        [TestMethod()]
        public void VerificaExecutaPartida()
        {
            List<Filme>[] lista = new List<Filme>[2];
            lista[0] = new List<Filme>() { listaFilme[0], listaFilme[1] };
            lista[1] = new List<Filme>() { listaFilme[2], listaFilme[3] };
            var filmes = lista.ExecutarEliminatorias().ExecutaPartida();
            Assert.AreEqual(filmes.Nota, 8.5, 0.0001);
        }

        /// <summary>
        /// Verifica ExecutaPartidaFinal
        /// </summary>
        [TestMethod()]
        public void VerificaExecutaPartidaFinal()
        {
            List<Filme>[] lista = new List<Filme>[2];
            lista[0] = new List<Filme>() { listaFilme[0], listaFilme[1] };
            lista[1] = new List<Filme>() { listaFilme[2], listaFilme[3] };
            var filmes = lista.ExecutarEliminatorias().ExecutaPartidaFinal();
            Assert.AreEqual(filmes.Count(), 2);
        }

        /// <summary>
        /// Limpa a referência da lista para encerrar os testes
        /// </summary>
        [TestCleanup()]
        public void FinalizaExecucaoDosTeste()
        {
            listaFilme = null;
        }
    }
}