using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class HomeController : Controller
    {
        private ILaywerServices _service { get; set; }
        public HomeController(ILaywerServices service)
        {
            _service = service;
        }
        public IActionResult Main(string title)
        {
            var articles = _service.GetArticlesByTitle(title);
            return View(articles);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }
    }
}
