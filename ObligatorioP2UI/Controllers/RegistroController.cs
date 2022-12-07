using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP2UI.Controllers
{
    public class RegistroController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult RegisterView()
        {
            if (HttpContext.Session.GetString("UsuarioLogueado") == null)
            {
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }

        [HttpPost]
        public IActionResult RegisterView(UsuarioPeriodista u)
        {
            try
            {
                u.ValidarCamposVacios();
                u.ValidarMail();
                u.ValidarPassword();
                sistema.ValidarRegistro(u.Email);
                sistema.Registrar(u);   
                return RedirectToAction("LoginView", "Login");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

    }
}
