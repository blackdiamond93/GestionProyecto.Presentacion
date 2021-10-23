using Microsoft.AspNetCore.Mvc;

namespace GestionProyecto.Presentacion.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
