using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes.PageObjects
{
    public class AcompanharDenunciaPO
    {
        private IWebDriver driver;
        private By byInputIdDenuncia;
        private By byBtnVerificar;

        public AcompanharDenunciaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byInputIdDenuncia = By.Id("inputIdDenuncia");
            this.byBtnVerificar = By.Id("btnVerificarDenuncia");
        }

        public void Navegar()
        {
            driver.Navigate().GoToUrl("http://localhost:8001/Denuncias/AcompanharDenuncia");
        }

        public void PreencherCampoAcompanharDenuncia(string _idDenuncia)
        {
            driver.FindElement(byInputIdDenuncia).SendKeys(_idDenuncia);
        }

        public void ClicarBotaoVerificar()
        {
            driver.FindElement(byBtnVerificar).Click();
        }

    }
}
