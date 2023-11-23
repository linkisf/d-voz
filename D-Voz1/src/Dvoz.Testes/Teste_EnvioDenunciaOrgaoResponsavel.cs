using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using D_Voz1.Controllers;
using D_Voz1.Models;

namespace Dvoz.Testes
{
    public class Teste_EnvioDenunciaOrgaoResponsavel
    {
        [Fact]
        public void EnviarDenunciaOrgaoResponsavel()
        {
            //ARRANGE
            DenunciasController submit = new DenunciasController();

            DenunciaIdentificadaModel denuncia = new DenunciaIdentificadaModel
            {
                Nome = "Teste",
                RG = "1231321",
                Email = "teste@teste.com",
                CPF = "4111112541",
                LocalDaDenuncia = "Salvador",
                LocalDoOcorrido = "Salvador",
                CEP = "00000"
            };

            var jsonContent = JsonSerializer.Serialize(denuncia);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //ACT
            var retorno = submit.EnviarDenunciaOrgaoResponsavel(content);

            //ASSERT
            Assert.Contains("201", retorno.Result.ToString());

        }
    }
}

