using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Dvoz.Testes
{
    public class Teste_AcompanharDenuncia
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Teste_AcompanharDenuncia()
        {
            driver = new ChromeDriver();
            wait = new(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void AcompanharDenuncia()
        {
            try
            {
                driver.Navigate().GoToUrl("http://localhost:8001/Denuncias/AcompanharDenuncia");

                IWebElement inputField = driver.FindElement(By.Id("id"));
                IWebElement submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));

                inputField.SendKeys("1");
                submitButton.Click();


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
    }
}

   

