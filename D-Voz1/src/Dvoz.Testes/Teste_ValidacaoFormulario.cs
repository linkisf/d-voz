using Dvoz.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes
{
    public class Teste_ValidacaoFormulario
    {
        private IWebDriver driver;
        private readonly WebDriverWait wait;

        public Teste_ValidacaoFormulario()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void ValidandoCamposFormulario()
        {
            //ARRANGE
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            denunciaIdentificadaPO.PreencherFormulario(
                "Teste",
                "0000000000",
                "teste@teste.com",
                "00000000000",
                "teste local da denuncia",
                "teste local do ocorrido",
                "00000000"
                );

            //ACT 
            denunciaIdentificadaPO.SubmeteFormulario();

            //ASSERT            
            Assert.Contains("SUCESSO", driver.PageSource);
        }

        [Fact]
        public void ValidandoCamposFormulario_Email()
        {
            //ARRANGE
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();

            //ACT
            bool verificacao = denunciaIdentificadaPO.VerificaCampoEmail();

            //ASSERT
            Assert.True(verificacao);
        }

        [Fact]
        public void ValidandoCamposFormulario_Nome()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoNome());
        }

        [Fact]
        public void ValidandoCamposFormulario_RG()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoRG());
        }

        [Fact]
        public void ValidaCamposFormulario_CPF()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoCPF());
        }

      

        [Fact]
        public void ValidaCamposFormulario_LocalDenuncia()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoLocalDenuncia());
        }

        [Fact]
        public void ValidaCamposFormulario_LocalOcorrido()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoLocalOcorrido());
        }

        [Fact]
        public void ValidaCamposFormulario_CEP()
        {
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();
            Assert.True(denunciaIdentificadaPO.VerificaCampoCEP());
        }
    }
}
