using Microsoft.AspNetCore.Mvc;
using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ObligatorioP2UI.Controllers
{
    public class PartidosEntreFechas : Controller
    {
        Sistema sistema = Sistema.Instancia;
        public IActionResult ListarPartidoEntreFechas()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }

        [HttpPost]
        public IActionResult ListarPartidoEntreFechasListado(DateTime Fecha1, DateTime Fecha2)
        {
            if (Fecha1 == null || Fecha2 == null)
            {
                ViewBag.NombreError = "Las fechas no pueden ser nulas";
                return View();
            }
            else
            {
                try
                {
                    List<Partido> partidos = sistema.ListarPartidosEntreFechas(Fecha1, Fecha2);
                    return View(partidos);
                }
                catch (Exception e)
                {
                    ViewBag.NombreError = e.Message;
                    return View();
                }
            }

        }
    }
}
