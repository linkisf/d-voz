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
    public class Teste_ValidacaoFormulario
    {
        private IWebDriver driver;

        public Teste_ValidacaoFormulario()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void ValidandoCamposFormulario()
        {
            //arrange
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

            //act 
            denunciaIdentificadaPO.SubmeteFormulario();

            //assert
            Assert.Contains("SUCESSO", driver.PageSource);
        }

        [Fact]
        public void ValidandoCamposFormulario_Email()
        {
            //arrange
            var denunciaIdentificadaPO = new DenunciaIdentificadaPO(driver);
            denunciaIdentificadaPO.Navegar();

            //act
            bool verificacao = denunciaIdentificadaPO.VerificaCampoEmail();

            //assert
            Assert.True(verificacao);
        }

    }
}
