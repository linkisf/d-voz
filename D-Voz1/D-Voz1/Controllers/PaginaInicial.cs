using Microsoft.AspNetCore.Mvc;

namespace D_Voz1.Controllers
{
    public class PaginaInicial : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Denuncie()
        {
            return View();
        }
    }
}
