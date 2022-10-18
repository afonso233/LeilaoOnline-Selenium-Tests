using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using Xunit;
using System;
using Alura.LeilaoOnline.Selenium.PageObejects;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar.")]
        public void AoEfetuarLoginValidoDeveCadastrarLeilao()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeiaoPO = new NovoLeialoPO(driver);
            novoLeiaoPO.Visitar();
            novoLeiaoPO.PreencheFormulario("Leilão de coleção",
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. " +
                "Nisi quibusdam esse saepe doloribus culpa ratione enim? " +
                "Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. " +
                "Soluta ab natus quia iusto!",

                "Item de Colecionador",
                4000,
                "C:\\Users\\henri\\Desktop\\imagem\\Arnold Wallpaper.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40));

            //Thread.Sleep(100000);
            //Act
            novoLeiaoPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
