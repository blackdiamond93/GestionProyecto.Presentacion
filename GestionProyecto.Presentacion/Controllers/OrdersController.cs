using GestionProyecto.Models.Request;
using GestionProyectos.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProyecto.Presentacion.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFacturaServices _facturaServices;
        private readonly IUsuarioServices _usuarioServices;
        private readonly IProductoServices _productoServices;
        public OrdersController(IFacturaServices facturaServices, IUsuarioServices usuarioServices,IProductoServices productoServices)
        {
            _facturaServices = facturaServices;
            _usuarioServices = usuarioServices;
            _productoServices = productoServices;
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
           
            ViewBag.list = await _facturaServices.GetFacturas();
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Orders()
        {
            ViewBag.listProduct = await  _productoServices.GetProductos();
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Orders(FacturaRequest facturaRequest)
        {
            facturaRequest.IdUsuario =Convert.ToInt32(User.Claims.Where(d => d.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault());
            facturaRequest.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var id = await _facturaServices.CreateFactura(facturaRequest);
                return Ok(id);
            }
            else
            {

                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> OrdersDetalles(DetalleRequest facturaRequest)
        {
          
            if (ModelState.IsValid)
            {

                var list = await _facturaServices.CreateDatalles(facturaRequest);
                return Ok(list);
            }
            else
            {

                return BadRequest();
            }

        }


        public async Task<IActionResult> GetClient()
        {
            var list = await _usuarioServices.GetClient();

            return  Ok( list);
        }

        public async Task<IActionResult> GetProduct(int id)
        {
            var list = await _productoServices.GetProducto(id);

            return Ok(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Report()
        {
            var list = await _facturaServices.GetFacturas();
            return View(list);


        }
        public async Task<ActionResult> Print()
        {
            var list = await _facturaServices.GetFacturas();
            return new ViewAsPdf("Report", list)
            { FileName = "Factura.pdf" };
        }
    }
}
