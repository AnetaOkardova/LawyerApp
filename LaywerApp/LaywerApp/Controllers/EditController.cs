using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class EditController : Controller
    {
        private ILaywerServices _service { get; set; }
        public EditController(ILaywerServices service)
        {
            _service = service;
        }
        
        public IActionResult EditOverview(string title, string name, string serviceTitle)
        {
            var articles = _service.GetArticlesByTitle(title);
            var collaborators = _service.GetCollaboratorsByName(name);
            var lawServices = _service.GetServicesByTitle(serviceTitle);
            var articlesAndCollaborators = new ArticlesCollaboratorsLawServices();
            articlesAndCollaborators.Articles = articles;
            articlesAndCollaborators.Collaborators = collaborators;
            articlesAndCollaborators.LawServices = lawServices;
            return View(articlesAndCollaborators);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                _service.CreateArticle(article);
                return RedirectToAction("Main", "Home");
            }
            return View(article);
        }
        public IActionResult DeleteArticle(int id)
        {
            var response = _service.DeleteArticle(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview");
            }
            else
            {
                //implement success message
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        
        [HttpGet]
        public IActionResult CreateCollaborator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCollaborator(Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _service.CreateCollaborator(collaborator);
                return RedirectToAction("Main", "Home");
            }
            return View(collaborator);
        }
        public IActionResult DeleteCollaborator(int id)
        {
            var response = _service.DeleteCollaborator(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview");
            }
            else
            {
                //implement success message
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }

        [HttpGet]
        public IActionResult CreateLawService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLawService(LawService lawService)
        {
            if (ModelState.IsValid)
            {
                _service.CreateLawService(lawService);
                return RedirectToAction("Main", "Home");
            }
            return View(lawService);
        }
        public IActionResult DeleteLawService(int id)
        {
            var response = _service.DeleteLawService(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview");
            }
            else
            {
                //implement success message
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }

    }
}
