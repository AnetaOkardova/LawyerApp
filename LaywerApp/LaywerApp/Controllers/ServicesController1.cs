using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class ServicesController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
