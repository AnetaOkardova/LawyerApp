using LaywerApp.Common;
using LaywerApp.Mappings;
using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
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


        public IActionResult EditOverview(string title, string name, string serviceTitle, string successMessage, string errorMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
            var id = int.Parse(User.FindFirst("Id").Value);
            var collaborators = _service.GetCollaboratorsByName(name);
            var collaboratorsToModify = collaborators.Where(x => x.Id != id).ToList();
            var articles = _service.GetArticlesByTitle(title);
            var lawServices = _service.GetServicesByTitle(serviceTitle);

            var articlesAndCollaborators = new ArticlesCollaboratorsLawServices();
            articlesAndCollaborators.Articles = articles;
            articlesAndCollaborators.Collaborators = collaboratorsToModify;
            articlesAndCollaborators.LawServices = lawServices;

            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;

            return View(articlesAndCollaborators);
        }


        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateArticle(CreateArticleModel article)
        {
            var domainModel = article.ToModel();
            if (ModelState.IsValid)
            {
                _service.CreateArticle(domainModel);
                return RedirectToAction("Main", "Home");
            }
            return View(article);
        }
        public IActionResult DeleteArticle(int id)
        {
            var response = _service.DeleteArticle(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            try
            {
                var article = _service.GetArticleById(id);
                return View(article.ToUpdateArticleModel());
            }
            catch (LaywerAppException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
        [HttpPost]
        public IActionResult UpdateArticle(UpdateArticleModel article)
        {
            var domainModel = article.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateArticle(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(article);
            }
        }


        [HttpGet]
        public IActionResult CreateCollaborator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCollaborator(CreateCollaboratorModel collaborator)
        {
            var domainModel = collaborator.ToModel();

            if (ModelState.IsValid)
            {
                _service.CreateCollaborator(domainModel);
                return RedirectToAction("Main", "Home");
            }
            return View(collaborator);
        }
        public IActionResult DeleteCollaborator(int id)
        {
            var response = _service.DeleteCollaborator(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult UpdateCollaborator(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorById(id);
                return View(collaborator.ToUpdateCollaboratorModel());
            }
            catch (LaywerAppException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpPost]
        public IActionResult UpdateCollaborator(UpdateCollaboratorModel collaborator)
        {
            var domainModel = collaborator.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateCollaborator(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(collaborator);
            }
        }


        [HttpGet]
        public IActionResult CreateLawService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLawService(CreateLawServiceModel lawService)
        {
            var domainModel = lawService.ToModel();

            if (ModelState.IsValid)
            {
                _service.CreateLawService(domainModel);
                return RedirectToAction("Main", "Home");
            }
            return View(lawService);
        }
        public IActionResult DeleteLawService(int id)
        {
            var response = _service.DeleteLawService(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult UpdateLawService(int id)
        {
            try
            {
                var service = _service.GetLawServicesById(id);
                return View(service.ToUpdateLawServiceModel());
            }
            catch (LaywerAppException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpPost]
        public IActionResult UpdateLawService(UpdateLawServiceModel service)
        {
            var domainModel = service.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateLawService(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("EditOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(service);
            }
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult ToggleAdminRole(int id)
        {
            var response = _service.ToggleAdminRole(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", new { SuccessMessage = "User updated successfully." });
            }
            else
            {
                return RedirectToAction("EditOverview", new { ErrorMessage = response.Message });
            }
        }

    }
}
