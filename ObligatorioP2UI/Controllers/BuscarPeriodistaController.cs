using Microsoft.AspNetCore.Mvc;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ObligatorioP2UI.Controllers
{
    public class BuscarPeriodistaController : Controller
    {
        Sistema sistema = Sistema.Instancia;
        public IActionResult GetBuscarPeriodistaPorEmail()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }

        [HttpPost]
        public IActionResult PostBuscarPeriodistaPorEmail(UsuarioPeriodista p)
        {
            string emailPeriodista = p.Email;
            List<Partido> PartidosConRoja = sistema.BuscarReseniasConRoja(emailPeriodista);
            return View(PartidosConRoja);
        }
    }
}
