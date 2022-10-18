﻿using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObejects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
       
        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }
        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;            
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
           
        }        
       
    }
}
