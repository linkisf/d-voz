using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes.PageObjects
{
    public class MenuNavegacaoPO
    {
        private readonly IWebDriver driver;
        private readonly By linkPaginaIncial_MenuNav;
        private readonly By linkDenuncie_MenuNav;
        private readonly By linkMinhaDenuncia_MenuNav;

        public MenuNavegacaoPO(IWebDriver driver)
        {
            this.driver = driver;
            this.linkPaginaIncial_MenuNav = By.Id("linkManuNavPaginaInicial");
            this.linkDenuncie_MenuNav = By.Id("linkManuNavDenuncie");
            this.linkMinhaDenuncia_MenuNav = By.Id("linkManuNavMinhaDenuncia");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
        }

        public void LinkPaginaInicialMenuNav()
        {
            driver.FindElement(linkPaginaIncial_MenuNav).Click();
        }

        public void LinkDenuncieMenuNav()
        {
            driver.FindElement(linkDenuncie_MenuNav).Click();
        }

        public void LinkMinhaDenunciaMenuNav()
        {
            driver.FindElement(linkMinhaDenuncia_MenuNav).Click();
        }

        public void VerificaExistenciaLinkDenuncie()
        {
            Assert.Contains("Denuncie", driver.PageSource); //instanciar elemento menu nav ao inves da pagina e procurar por elementos dentro 
        }


    }
}
