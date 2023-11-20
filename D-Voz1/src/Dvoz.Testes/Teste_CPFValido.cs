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
    public class Teste_CPFValido: IDisposable
    {
        private IWebDriver driver;

        public Teste_CPFValido()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void CarregaPaginaInicialVerificaExistenciaLinkDenuncie()
        {            
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);    
        }

        [Fact]
        public void AcessandoPaginaDenuncieMenuNav()
        {
            var denunciaIdentificadaPO = new NavegacaoPaginaInicialPO(driver);

            denunciaIdentificadaPO.Navegar("http://localhost:8001");
            denunciaIdentificadaPO.LinkDenunciaMenuNav();
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
