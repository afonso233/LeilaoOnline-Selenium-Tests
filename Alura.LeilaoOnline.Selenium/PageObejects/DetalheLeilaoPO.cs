﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObejects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver driver;
        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;       
        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }
        public double LanceAtual
        {
            get
            {
                var valorTexto = driver.FindElement(byLanceAtual).Text;
                var valor = double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
                return 0;
            }
        }
        public void Visitar(int idLeilao)
        {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/1{idLeilao}");
        }

        internal void OfertarLance(double valor)
        {
            driver.FindElement(byInputValor).SendKeys(valor.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}
