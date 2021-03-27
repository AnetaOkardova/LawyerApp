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
        public IActionResult ArticleDetails(int id)
        {
            var article = _service.GetArticleById(id);
            if (article == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(article);
        }

        public IActionResult LawService(string title)
        {
            var services = _service.GetServicesByTitle(title);
            return View(services);
        }
        public IActionResult LawServiceDetails(int id)
        {
            var service = _service.GetLawServicesById(id);

            if (service == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(service);
        }
    }
}
