using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
