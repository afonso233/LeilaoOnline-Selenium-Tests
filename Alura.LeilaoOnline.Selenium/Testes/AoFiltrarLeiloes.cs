using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using Xunit;
using System;
using Alura.LeilaoOnline.Selenium.PageObejects;
using System.Threading;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;
        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

       [Fact]
       public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("henriquexd_96@hotmail.com", "123");
            loginPO.SubmeteFormulario();

            var dashBoardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashBoardInteressadaPO.Filtro.PesquisarLeiloes(new List<string> { "Arte", "Coleções" }, "", true);

            //Assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }
        
    }
}
