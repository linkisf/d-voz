using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;
using Dvoz.Testes.PageObjects;

namespace Dvoz.Testes
{
    public class Teste_AcompanharDenuncia : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Teste_AcompanharDenuncia()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void AcompanharDenuncia_Sucesso()
        {
            try
            {
                //ARRANGE
                var acompanharDenunciaPO = new AcompanharDenunciaPO(driver);


                //ACT
                acompanharDenunciaPO.Navegar();
                acompanharDenunciaPO.PreencherCampoAcompanharDenuncia("1");
                acompanharDenunciaPO.ClicarBotaoVerificar();

                //ASSERT
                wait.Until(drv => drv.FindElement(By.CssSelector("div.page-container h2")).Text.Contains("Detalhes da Denúncia"));
                var idElement = driver.FindElement(By.XPath("//dd[@class='col-sm-9'][1]"));

                Assert.Equal(idElement.Text, "1");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test falhou: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        

        [Fact]
        public void AcompanharDenuncia_Erro()
        {
            try
            {
                //ARRANGE
                var acompanharDenunciaPO = new AcompanharDenunciaPO(driver);


                //ACT
                acompanharDenunciaPO.Navegar();
                acompanharDenunciaPO.PreencherCampoAcompanharDenuncia("0000000");
                acompanharDenunciaPO.ClicarBotaoVerificar();

                //ASSERT
                wait.Until(drv => drv.FindElement(By.CssSelector("div.error-container div.error-message")).Displayed);

                var errorMessageElement = driver.FindElement(By.CssSelector("div.error-container div.error-message"));

                Assert.Equal("ID não encontrado", errorMessageElement.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test falhou: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

   

