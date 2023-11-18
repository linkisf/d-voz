using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Dvoz.Testes.PageObjects
{
    public class DenunciaIdentificadaPO
    {
        private IWebDriver driver;
        private By byInputNome;
        private By byInputRG;
        private By byInputEmail;
        private By byInputCPF;
        private By byInputLocalDenuncia;
        private By byInputLocalOcorrido;
        private By byInputCEP;
        private By byBotaoEnviarDenuncia;



        public DenunciaIdentificadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputNome = By.Id("Nome");
            byInputRG = By.Id("RG");
            byInputEmail = By.Id("Email");
            byInputCPF = By.Id("CPF");
            byInputLocalDenuncia = By.Id("LocalDenuncia");
            byInputLocalOcorrido = By.Id("LocalOcorrido");
            byInputCEP = By.Id("CEP");
            byBotaoEnviarDenuncia = By.CssSelector("button[type=submit]");
        }

        public void Navegar()
        {
            driver.Navigate().GoToUrl("http://localhost:8001/Denuncias/DenunciaIdentificada");
        }

        public void PreencherFormulario(
            string nome,
            string rg,
            string email,
            string cpf,
            string localDenuncia,
            string localOcorrido,
            string cep
            )
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputRG).SendKeys(rg);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputCPF).SendKeys(cpf);
            driver.FindElement(byInputLocalDenuncia).SendKeys(localDenuncia);
            driver.FindElement(byInputLocalOcorrido).SendKeys(localOcorrido);
            driver.FindElement(byInputCEP).SendKeys(cep);
        }

        public void SubmeteFormulario() 
        {
            driver.FindElement(byBotaoEnviarDenuncia).Click();
        }


    }
}

