using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using Xunit;
using System;
using Alura.LeilaoOnline.Selenium.PageObejects;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Edge Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;
        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }
        [Fact(Skip = "Teste ainda não implementado. Ignorar.")]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //Arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencherFormulario(login: "henriquexd_96@hotmail.com",
                 senha: "123");
            
            var detalheLeilaoPO = new DetalheLeilaoPO(driver);
            detalheLeilaoPO.Visitar(1); //em andamento

            //Act
            detalheLeilaoPO.OfertarLance(300);

            //Assert 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalheLeilaoPO.LanceAtual == 300);
            
            Assert.True(iguais);
        }
    }
}
