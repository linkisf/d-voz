﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvoz.Testes.PageObjects
{
    public class NavegacaoPaginaInicialPO
    {
        private readonly IWebDriver driver;
        private readonly By linkDenunciaMenuNav;
        private readonly By linkBtnDenuncia;
        private readonly By linkBtnFormularioIdentificado;
        private readonly By imagemDenunciaIdentificada;
        private readonly By botaoDenuncieNaHome;
        private readonly By formDenunciaIdentificada;

        public NavegacaoPaginaInicialPO(IWebDriver driver)
        {
            this.driver = driver;
            linkDenunciaMenuNav = By.LinkText("Denuncie");
            linkBtnDenuncia = By.Id("btn_denuncie");
            linkBtnFormularioIdentificado = By.Id("btnDenunciaIdentificada");
            imagemDenunciaIdentificada = By.Id("denunciaIdentificadaImagem");
            botaoDenuncieNaHome = By.Id("link_denuncie");
            formDenunciaIdentificada = By.Id("formDenunciaIdentificada");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
            //driver.Manage().Window.Size = new System.Drawing.Size(1918, 1030);
        }

        public void LinkDenunciaMenuNav()
        {
            driver.FindElement(linkDenunciaMenuNav).Click();
        }

        public void LinkBtnDenuncia()
        {
            driver.FindElement(linkBtnDenuncia).Click();
        }

        public void LinkBtnFormularioIdentificado()
        {
            driver.FindElement(linkBtnFormularioIdentificado).Click();
        }

        public void ClicarImagemFormularioIdentificado()
        {
            driver.FindElement(imagemDenunciaIdentificada).Click();
        }

        public void VerificaExistenciaLinkDenuncie()
        {   
            Assert.Contains("Denuncie", driver.PageSource);
        }

        public void ClicarBotaoDenuncieNaHome()
        {
            driver.FindElement(botaoDenuncieNaHome).Click();
        }

        public void EstaNaPaginaFormDenunciaIdentificada()
        {
            Assert.EndsWith("DenunciaIdentificada", driver.Url);
        }

        public void ContemFormularioDenunciaIdentificada()
        {
            driver.FindElement(formDenunciaIdentificada);
        }
    }
}
