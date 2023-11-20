using Dvoz.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

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
            navegacaoPO.ClicarImagemFormularioIdentificado();
            navegacaoPO.EstaNaPaginaFormDenunciaIdentificada();
            navegacaoPO.ContemFormularioDenunciaIdentificada();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
