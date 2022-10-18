using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObejects
{
    public class NovoLeialoPO
    {
        private IWebDriver driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;
       

        public NovoLeialoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button[type=submit]");

        }
        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria));
                //elementoCategoria.FindElements(By.TagName("option"));
                return elementoCategoria.Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            }
        }
         public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }
        public void PreencheFormulario(string titulo, 
            string descricao, 
            string cateogria,
            double valorInicial, 
            string imagem, 
            DateTime inicioPregao,
            DateTime terminoPregao)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).SendKeys(cateogria);
            driver.FindElement(byInputValorInicial).SendKeys(valorInicial.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicioPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(terminoPregao.ToString("dd/MM/yyyy"));

        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
