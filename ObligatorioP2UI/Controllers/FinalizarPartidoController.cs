using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP2UI.Controllers
{
    public class FinalizarPartidoController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult FinalizarPartido(int partidoId)
        {

            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                ViewBag.partidoId = partidoId;
                try
                {
                    sistema.FinalizarPartido(partidoId);
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
                return RedirectToAction("ListarPartidosCerrados", "Listados");
            }
            return RedirectToAction("Mostrar", "Error");
        }
    }
}
