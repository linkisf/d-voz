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
    public class Teste_DenunciaNavegacao: IDisposable
    {
        private readonly IWebDriver driver;
        private readonly NavegacaoPaginaInicialPO navegacaoPO;

        public Teste_DenunciaNavegacao()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            navegacaoPO = new NavegacaoPaginaInicialPO(driver);
        }

        [Fact]
        public void AcessarPaginaFormDenunciaIdentificada()
        {
            // Navegar para pagina de escolha de denuncia
            navegacaoPO.Navegar("http://localhost:8001/PaginaInicial/Denuncie");
            navegacaoPO.LinkBtnFormularioIdentificado();
            navegacaoPO.EstaNaPaginaFormDenunciaIdentificada();
            navegacaoPO.ContemFormularioDenunciaIdentificada();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
