using Alura.LeilaoOnline.Selenium.Fixture;
using Alura.LeilaoOnline.Selenium.PageObejects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeAposLogout()
        {
            //Arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("henriquexd_96@hotmail.com")
                .InformarSenha("123")
                .EfetuarLogin();
           
            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //Act - Efetuar Logout
            dashboardInteressadaPO.Menu.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
