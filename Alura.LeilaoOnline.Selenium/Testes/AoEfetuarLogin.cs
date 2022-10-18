using Alura.LeilaoOnline.Selenium.Fixture;
using Alura.LeilaoOnline.Selenium.PageObejects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void AoEfetuarLoginValidoDeveIrParaDashBoard()
        {
            //Arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();

            loginPo.PreencherFormulario(login: "henriquexd_96@hotmail.com",
                senha: "123");

            //Act
            loginPo.SubmeteFormulario();

            //Assert
            Assert.Contains("Dashboard", driver.Title);

        }

        [Fact]
        public void AoEfetuarLoginInvalidoDeveContinuarLogin()
        {
            //Arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();

            loginPo.PreencherFormulario(login: "henriquexd_96@hotmail.com",
                senha: "");

            //Act
            loginPo.SubmeteFormulario();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }
    }

}
