using D_Voz1.Controllers;
using Dvoz.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Dvoz.Testes
{
    public class Teste_CPFValido
    {
        [Fact]
        public void ValidaCPF()
        {
            DenunciasController denuncias = new DenunciasController();

            Assert.True(denuncias.ValidarCPF("12345678909"));
        }
    }
}
