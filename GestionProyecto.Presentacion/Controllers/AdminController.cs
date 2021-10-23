using GestionProyectos.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionProyecto.Presentacion.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public AdminController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListUsuarios()
        {
            ViewBag.list = await _usuarioServices.GetClient();
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListOrders()
        {
            ViewBag.list = await _usuarioServices.GetClient();
            return View();
        }
    }
}
