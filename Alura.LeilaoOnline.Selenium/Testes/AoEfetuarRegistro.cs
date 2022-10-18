using Alura.LeilaoOnline.Selenium.Fixture;
using Alura.LeilaoOnline.Selenium.PageObejects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;

        }
        [Fact]
        public void AposEfetuarRegistroDeveIrParaPaginaDeAgradecimento()
        {
            //Arrange - Dado edge aberto, página inicial do sistema de leilões,
            //dados de registro válidos informados        
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(nome: "Afonso Henrique",
                email: "henriquexd_96@hotmail.com",
               password: "123",
               confirmPassword: "123");

            //Act - Efetuo o registro
            registroPO.SubmeteFormulario();

            //Assert - Devo ser redirecionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "henriquexd_96@hotmail.com", "123", "123")]
        [InlineData("Afonso Henrique", "henriquexd", "123", "123")]
        [InlineData("Afonso Henrique", "henriquexd_96@hotmail.com", "123", "321")]
        [InlineData("Afonso Henrique", "henriquexd_96@hotmail.com", "123", "")]
        public void AposEfetuarRegistroInformacoesInvalidasDeveContinuarNaHome(string nome,
            string email, string password, string confirmPassword)
        {
            //Arrange - Dado edge aberto, página inicial do sistema de leilões,
            //dados de registro válidos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(nome, email, password, confirmPassword);

            //Act - Efetuo o registro
            registroPO.SubmeteFormulario();

            //Assert - Devo ser redirecionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoMostrarMenssagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //Act
            registroPO.SubmeteFormulario();
            //Assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);

        }

        [Fact]
        public void DadoEmailInvalidoMostrarMenssagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            //Email
            registroPO.PreencheFormulario(nome: "",
                email: "henriquexd",
                password: "",
                confirmPassword: "");

            //Act
            registroPO.SubmeteFormulario();
            //Assert          
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
