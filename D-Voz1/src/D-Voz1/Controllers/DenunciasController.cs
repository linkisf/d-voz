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

        public IActionResult AcompanharDenuncia()
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
                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                var responseJson = JsonSerializer.Deserialize<JsonElement>(responseString);

                var id = responseJson.GetProperty("id").GetInt32().ToString();

                ViewBag.Id = id;
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

        [HttpPost]
        public async Task<IActionResult> SearchReport(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                ViewBag.ErrorMessage = "ID da denúncia é necessário";
                return View("DenunciaError");
            }

            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:3000/denunciasIdentificadas/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var denunciaDetails = JsonSerializer.Deserialize<AcompanharDenunciaModel>(responseContent);

                    return View("DenunciaDetails", denunciaDetails);
                }
                else
                {
                    return View("DenunciaError");
                }
            }
            catch (HttpRequestException)
            {
                return View("DenunciaError");
            }
        }
    }
}

