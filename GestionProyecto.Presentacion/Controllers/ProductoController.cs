using GestionProyecto.Models.Request;
using GestionProyectos.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionProyecto.Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServices _services;
        private readonly ICategoriaServices _servicesCategoria;
        public ProductoController( IProductoServices services ,ICategoriaServices categoriaServices)
        {
            _services = services;
            _servicesCategoria = categoriaServices;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.lista = await _services.GetProductosForCategori();
            return View();
        }
        public async Task<IActionResult> Services()
        {
            ViewBag.lista = await _services.GetServices();
            return View();
        }

        [Authorize(Roles ="Admin")]
        public async Task< IActionResult> CreateProduct()
        {
            ViewBag.list = await _servicesCategoria.GetCategorias();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public  async Task<IActionResult> CreateProduct(ProductoRequest productoRequest)
        {
            if (ModelState.IsValid)
            {
                var produc = await _services.CreateProducto(productoRequest);
                if (produc)
                {
                    return RedirectToAction("ListProduct", "Producto");
                }
                else
                {
                    ViewBag.Error = "Error en los datos enviados";
                    return View();
                }
               
            }
            else
            {
                ViewBag.Error = "Error en los datos enviados";
                return View();
            }
           
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListProduct()
        {
            var list = await _services.GetProductos();

            ViewBag.list = list;

            return View();
        }

        [Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> EditProduct(int id)
        {
            ViewBag.id = id;
            ViewBag.list = await _servicesCategoria.GetCategorias();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductoRequest productoRequest)
        {
            if (ModelState.IsValid)
            {
                var produc = await _services.UpdateProducto(productoRequest);
                if (produc)
                {
                    return RedirectToAction("ListProduct", "Producto");
                }
                else
                {
                    ViewBag.Error = "Error en los datos enviados";
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "Error en los datos enviados";
                return View();
            }
        }

    }
}
