using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using Xunit;
using System;
using Alura.LeilaoOnline.Selenium.PageObejects;
using System.Threading;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
       public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeiaoPO = new NovoLeialoPO(driver);

            //Act
            novoLeiaoPO.Visitar();

            //Assert
            Assert.Equal(3, novoLeiaoPO.Categorias.Count());

        }
    }
}
