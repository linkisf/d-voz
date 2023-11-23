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
            var pPaginaIncialPO = new NavegacaoPaginaInicialPO(driver);
            var pEscolhaDenunicaPO = new EscolhaTipoDenunciaPO(driver);
            var pDenunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            
            // Navegar para pagina de escolha de denuncia
            pPaginaIncialPO.Navegar("http://localhost:8001");
            pPaginaIncialPO.LinkBtnDenuncia();

            pEscolhaDenunicaPO.LinkBtnFormularioIdentificado();

            pDenunciaIdentificadaPO.EstaNaPaginaFormDenunciaIdentificada();
            pDenunciaIdentificadaPO.ContemFormularioDenunciaIdentificada();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
