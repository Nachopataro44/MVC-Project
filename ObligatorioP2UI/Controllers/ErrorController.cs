﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioP2UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Mostrar()
        {
            return View();
        }
    }
}
