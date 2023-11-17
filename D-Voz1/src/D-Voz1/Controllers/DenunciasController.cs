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
        public async Task<IActionResult> SubmitReport(DenunciaIdentificadaModel denunciaIdentificadaModel)
        {
            var jsonContent = JsonSerializer.Serialize(denunciaIdentificadaModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://url/reports", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Confirmation");
                }
                else
                {
                    // ViewBag.ErrorMessage = "Mensagem de erro";
                    return View("DenunciaIdentificada");
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = ex;
                return View("DenunciaIdentificada");
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

