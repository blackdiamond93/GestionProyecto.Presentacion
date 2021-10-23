using GestionProyecto.Models.Request;
using GestionProyectos.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace GestionProyecto.Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRolServices _rolServices;
        private readonly IPersonaServices _personaServices;

        public UsuarioController(IUsuarioServices usuarioServices, IRolServices rolServices, IPersonaServices personaServices)
        {
            _usuarioServices = usuarioServices;
            _rolServices = rolServices;
            _personaServices = personaServices;
        }
      
      
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UsuarioRequest usuarioRequest)
        {
            if (ModelState.IsValid)
            {
                var user = await _usuarioServices.Login(usuarioRequest);
                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.Usuarios));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, user.Rols));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.Error = "Usuario o Contraseña incorrecto";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> CreateUser()
        {
            ViewBag.listRoles = await _rolServices.GetCategorias();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm]UsuarioRequest usuarioRequest)
        {
            var usuario = await _usuarioServices.CreateUsuario(usuarioRequest);

            
            if (usuario)
            {

                return RedirectToAction("Login","Usuario");
            }
            else
            {
                ViewBag.Error = "Error al crear usuario";
                return View();
            }
            
        }
        public IActionResult CreatePersona()
        {
            
            return View();
        }
        [Authorize]
        public async Task< IActionResult> Profile()
        {
            var identity = Convert.ToInt32( User.Claims.Where(d => d.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault());
            if (identity<0)
            {
                return Redirect("/");
            }
            else
            {
                ViewBag.User = await _personaServices.GetPersona(identity);
                return View();
            }

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePersona(PersonaRequest personaRequest)
        {
            if (ModelState.IsValid)
            {
                personaRequest.IdUsuario= Convert.ToInt32(User.Claims.Where(d => d.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault());
                var persona = await _personaServices.CreatePersona(personaRequest);


                if (persona)
                {

                    return RedirectToAction("Profile","Usuario");
                }
                else
                {
                    ViewBag.Error = "ha Ocurrido un error vuelva a intentar";
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "Error en el modelo ";
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        [Authorize]
        public IActionResult EditPersona()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task< IActionResult> EditPersona(PersonaRequest persona)
        {
            if (ModelState.IsValid)
            {
                persona.IdUsuario =Convert.ToInt32(User.Claims.Where(d => d.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault());
                var per = await _personaServices.UpdatePersona(persona);
                if (per)
                {
                    return RedirectToAction("Profile","Usuario");
                }
                else
                {
                   
                    return RedirectToAction("CreatePersona","Usuario");
                }
            }
            else
            {
                ViewBag.Error = "Error en los datos enviados ";
                return View();
            }
            
        }
        [Authorize]
        public IActionResult ChangePass()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePass(PassRequest passRequest)
        {
            if (ModelState.IsValid)
            {
                passRequest.id = Convert.ToInt32(User.Claims.Where(d => d.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault());
                var change = await _usuarioServices.ResetPass(passRequest);
                if (change)
                {
                    return RedirectToAction("Porfile","Usuarios");
                }
                
            }
            ViewBag.Error = "Datos invalidos";
            return View();
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ListUsuarios()
        {
            var list = await _usuarioServices.GetUsers();
            if (list!=null)
            {
                ViewBag.list = list;
                return View();
            }
            else
            {
                ViewBag.Error = "Error con el servidor";
                return View();
            }
            
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Report()
        {
            var list = await _usuarioServices.GetClient();
            return View(list);

            
        }
        public async Task< ActionResult> Print()
        {
            var list = await _usuarioServices.GetClient();
            return new ViewAsPdf("Report",list)
            { FileName = "Test.pdf" };
        }
    }
}
