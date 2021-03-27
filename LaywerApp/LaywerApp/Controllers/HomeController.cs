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
        public IActionResult Main(string title, string name)
        {
            var articles = _service.GetArticlesByTitle(title);
            var collaborators = _service.GetCollaboratorsByName(name);
            var articlesAndCollaborators = new ArticlesAndCollaborators();
            articlesAndCollaborators.Articles = articles;
            articlesAndCollaborators.Collaborators = collaborators;
            return View(articlesAndCollaborators);
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

        public IActionResult CollaboratorsDetails(int id)
        {
            var collaborator = _service.GetCollaboratorById(id);

            if (collaborator == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(collaborator);
        }
    }
}
