using Dvoz.Testes.PageObjects;
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
    public class Teste_NavegarBotaoDenuncia: IDisposable
    {
        private IWebDriver driver;

        public Teste_NavegarBotaoDenuncia()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void AcessandoPaginaDenuncieMenuNav()
        {
            var navegacaoPO = new MenuNavegacaoPO(driver);

            navegacaoPO.Navegar("http://localhost:8001");
            navegacaoPO.LinkDenuncieMenuNav();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
