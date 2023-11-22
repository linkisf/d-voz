using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes.PageObjects
{
    public class PaginaInicialPO
    {
        private readonly IWebDriver driver;
        private readonly By linkBtnDenuncia;

        public PaginaInicialPO(IWebDriver driver)
        {
            this.driver = driver;
            this.linkBtnDenuncia = By.Id("link_denuncie");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
        }

        public void LinkBtnDenuncia()
        {
            driver.FindElement(linkBtnDenuncia).Click();
        }
    }
}
