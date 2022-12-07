using Microsoft.AspNetCore.Mvc;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ObligatorioP2UI.Controllers
{
    public class ReseniaController : Controller
    {
        Sistema sistema = Sistema.Instancia;
        public IActionResult ReseniaView(int partidoId)
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Periodista")
            {
                ViewBag.partidoId = partidoId;
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }

        [HttpPost]
        public IActionResult ReseniaView(Resenia r)
        {
            string PeriodistaLog = HttpContext.Session.GetString("UsuarioLogueado");
            if(r.Titulo is null || r.Contenido is null)
            {
                ViewBag.NombreError = "No pueden haber datos vacios";
                return View();
            }
            try
            {
                sistema.CrearResenia(r, PeriodistaLog);
                return RedirectToAction("ListarResenias", "Listados");
            }
            catch (Exception e)
            {
                ViewBag.NombreError = e.Message;
                return View();
            }
        }
    }
}
