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
        private IWebDriver driver;

        public Teste_DenunciaNavegacao()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void CarregaPaginaInicialVerificaExistenciaLinkDenuncie()
        {            
            var navegacaoPO = new NavegacaoPaginaInicialPO(driver);

            navegacaoPO.Navegar("http://localhost:8001");
            navegacaoPO.VerificaExistenciaLinkDenuncie();
        }

        [Fact]
        public void AcessandoPaginaDenuncieMenuNav()
        {
            var navegacaoPO = new NavegacaoPaginaInicialPO(driver);

            navegacaoPO.Navegar("http://localhost:8001");
            navegacaoPO.LinkDenunciaMenuNav();
        }

        [Fact]
        public void AcessandoPaginaDenuncieBotaoPrincipalEFormulario()
        {
            var navegacaoPO = new NavegacaoPaginaInicialPO(driver);

            navegacaoPO.Navegar("http://localhost:8001");
            navegacaoPO.LinkBtnDenuncia();
            navegacaoPO.LinkBtnFormularioIdentificado();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
