using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class InfoController1 : Controller
    {
        public IActionResult ErrorNotFound()
        {
            return View();
        }
    }
}
