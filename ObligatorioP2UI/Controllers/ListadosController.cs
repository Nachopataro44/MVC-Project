using Microsoft.AspNetCore.Mvc;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Obligatorio2UI.Controllers
{
    public class ListadosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        #region Listado para usuarios no logueados
        public IActionResult ListarSeleccionesNoLog()
        {
            if (HttpContext.Session.GetString("UsuarioLogueado") == null)
            {
                List<Seleccion> selecciones = sistema.VisualizarSelecciones();
                return View(selecciones);
            }
            return RedirectToAction("Mostrar", "Error");
        }
        #endregion
        #region Listado para Logueados
        public IActionResult ListarPartidosCerrados()
        {
            List<Partido> Partidos = null;
            if (HttpContext.Session.GetString("UsuarioLogueado") != null)
            {
                if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
                {
                    Partidos = sistema.Partidos;
                }
                else if(HttpContext.Session.GetString("UsuarioRol") == "Periodista")
                {
                    Partidos = sistema.ListarPartidosFinalizados();
                }
                return View(Partidos);
            }
            return RedirectToAction("Mostrar", "Error");

        }
        public IActionResult ListarResenias(string Periodista)
        {
            if (HttpContext.Session.GetString("UsuarioLogueado") != null)
            {
                string userLog = ""; 
                if (HttpContext.Session.GetString("UsuarioRol") == "Periodista")
                {
                    userLog = HttpContext.Session.GetString("UsuarioLogueado");
                }
                else
                {
                    userLog = Periodista;
                    ViewBag.Periodista = Periodista;
                }
                List<Resenia> Resenias = sistema.ListarReseniasDePeriodista(userLog);
                return View(Resenias);
            }
            return RedirectToAction("Mostrar", "Error");
        }

        public IActionResult ListarPartidoEntreFechas()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Mostrar", "Error");
        }
        
        [HttpPost]
        public IActionResult ListarPartidoEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Partido> partidos = sistema.ListarPartidosEntreFechas(fecha1, fecha2);
            return View(partidos);
        }

        public IActionResult ListarPeriodistas()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                List<UsuarioPeriodista> periodistas = sistema.listarPeriodistas();
                return View(periodistas);
            }
            return RedirectToAction("Mostrar", "Error");
        }

        public IActionResult ListarPartidoConMasGoles()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == "Operador")
            {
                List<Seleccion> listaSelecciones = sistema.BuscarSeleccionConMasGoles();
                return View(listaSelecciones);
            }
            return RedirectToAction("Mostrar", "Error");
        }
        #endregion
    }
}
