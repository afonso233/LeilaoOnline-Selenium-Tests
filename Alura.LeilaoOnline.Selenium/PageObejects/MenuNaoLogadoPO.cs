using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObejects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver driver;
        private By byMenuMobile;
        public bool MenuMobileVisivel
        {
            get
            {
                var elemento = driver.FindElement(byMenuMobile);
                return elemento.Displayed;
            }
        }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byMenuMobile = By.ClassName("sidenav-trigger");
        }
    }
}