using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes
{
    public class DenunciaNavegacao
    {
        [Fact]
        public void CarregaPaginaInicialVerificaExistenciaLinkDenuncie()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Act
            driver.Navigate().GoToUrl("http://localhost:7226/");
            //Assert
            Assert.Contains("Denuncie", driver.PageSource);
        }

        [Fact]
        public void AcessandoPaginaDenuncieMenuNav()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("http://localhost:7226/");
            driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
            driver.FindElement(By.LinkText("Denuncie")).Click();
        }

        [Fact]
        public void AcessandoPaginaDenuncieBotaoPrincipalEFormulario()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("http://localhost:7226/");
            driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
            driver.FindElement(By.Id("btn_denuncie")).Click();
            driver.FindElement(By.CssSelector(".borda-esquerda-redo > .nome-tipo-denuncia")).Click();
        }
    }
}
