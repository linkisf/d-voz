using Microsoft.AspNetCore.Mvc;
using D_Voz1.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace D_Voz1.Controllers
{
    public class DenunciasController : Controller
    {
        private readonly HttpClient _httpClient;

        public DenunciasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult DenunciaIdentificada()
        {
            return View();
        }
        public IActionResult DenunciaAnonima()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitReport(DenunciaIdentificadaModel denunciaIdentificadaModel)
        {
            var jsonContent = JsonSerializer.Serialize(denunciaIdentificadaModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> response = EnviarDenunciaOrgaoResponsavel(content);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Confirmacao");
            }
            else
            {
                ViewBag.ErrorMessage = "Mensagem de erro";
                return View("DenunciaIdentificada");
            }
        }

        public async Task<HttpResponseMessage> EnviarDenunciaOrgaoResponsavel(StringContent denuncia)
        {
            try
            {
                var response = await _httpClient.PostAsync("http://localhost:3000/denunciasIdentificadas", denuncia);

                return response;                
            }
            catch (HttpRequestException ex)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Gone);
                return response;
            }
        }

        public IActionResult Confirmacao()
        {
            return View();
        }
    }
}

