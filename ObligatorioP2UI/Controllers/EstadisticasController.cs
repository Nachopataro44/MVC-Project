using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP2UI.Controllers
{
    public class EstadisticasController : Controller
    {
        public IActionResult EstadisticasView()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }
    }
}
