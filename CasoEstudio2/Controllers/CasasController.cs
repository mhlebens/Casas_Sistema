using Microsoft.AspNetCore.Mvc;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
