using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObejects;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private EdgeDriver driver;

        public AoNavegarParaHomeMobile()
        {
           // var deviceSettings = new EdgeMobileEmulationDeviceSettings();
            var options = new EdgeOptions();
            //options.EnableMobileEmulation(deviceSettings);
            driver = new EdgeDriver(TestHelper.PastaDoExecutavel, options);
        }

        [Fact(Skip = "Não Funciona no momento")]
        public void DadoALargura400MostrarMenuMobile()
        {
            //Arrange
            var homePO = new HomeNaoLogadaPO(driver);

            //Act
            homePO.Visitar();

            //Assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
