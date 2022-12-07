using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP2UI.Controllers
{
    public class LoginController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult LoginView()
        {
            HttpContext.Session.Remove("UsuarioLogueado");
            HttpContext.Session.Remove("UsuarioRol");
            return View();
        }

        [HttpPost]
        public IActionResult LoginView(Usuario usuario)
        {
            try
            {
                sistema.Login(usuario);
            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message;
                return View();
            }
            Usuario userLogueado = sistema.Login(usuario);
            HttpContext.Session.SetString("UsuarioLogueado", userLogueado.Email);
            HttpContext.Session.SetString("UsuarioRol", userLogueado.ObtenerRol());

            return RedirectToAction("Index", "Home");
        }
    }
}
