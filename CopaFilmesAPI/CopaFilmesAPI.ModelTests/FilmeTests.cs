using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopaFilmesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                }
            };
        }

        /// <summary>
        /// Testa a ordenação da lista com base na definição de CompareTo definida na classe,
        /// compara o valor do primeiro registro da lista
        /// </summary>
        [TestMethod()]
        public void CompareToTest()
        {
            listaFilme.Sort();
            Assert.AreEqual(6.3, listaFilme[0].Nota, 0.0001);
        }

        /// <summary>
        /// Testa a ordenação da lista com base na definição de CompareTo definida na classe,
        /// compara o valor do segundo item da lista
        /// </summary>
        [TestMethod()]
        public void ComparaNotaDoSegundoItemDaListaTest()
        {
            listaFilme.Sort();
            Assert.AreEqual(6.7, listaFilme[1].Nota, 0.0001);
        }

        /// <summary>
        /// Testa a ordenação da lista com base na definição de CompareTo definida na classe,
        /// compara o valor do terceiro item da lista
        /// </summary>
        [TestMethod()]
        public void ComparaNotaDoTerceiroItemDaListaTest()
        {
            listaFilme.Sort();
            Assert.AreEqual(8.5, listaFilme[2].Nota, 0.0001);
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