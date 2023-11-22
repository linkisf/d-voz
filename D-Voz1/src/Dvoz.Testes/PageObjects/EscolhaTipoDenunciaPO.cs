using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes.PageObjects
{
    public class EscolhaTipoDenunciaPO
    {
        IWebDriver driver;
        private readonly By linkBtnFormularioIdentificado;

        public EscolhaTipoDenunciaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.linkBtnFormularioIdentificado = By.Id("btnDenunciaIdentificada");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
        }

        public void LinkBtnFormularioIdentificado()
        {
            driver.FindElement(linkBtnFormularioIdentificado).Click();
        }
    }
}
