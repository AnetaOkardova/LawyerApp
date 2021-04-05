using LaywerApp.Common;
using LaywerApp.Mappings;
using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
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

        public IActionResult Main(string title, string name, string serviceTitle)
        {
            var articles = _service.GetArticlesByTitle(title);
            var newArticles = articles.Select(x => x.ToArticleCardModel()).ToList();
            
            var collaborators = _service.GetCollaboratorsByName(name);
            var newCollaborators = collaborators.Select(x => x.ToCollaboratorCardModel()).ToList();
            
            var lawServices = _service.GetServicesByTitle(serviceTitle);
            var newServices = lawServices.Select(x => x.ToLawServiceCardModel()).ToList();

            var overviewModel = new OverviewModel();
            overviewModel.Articles = newArticles;
            overviewModel.Collaborators = newCollaborators;
            overviewModel.LawServices = newServices;
            return View(overviewModel);
        }
        public IActionResult LawServiceOverview(string title)
        {
            var services = _service.GetServicesByTitle(title);
            
            if (services.Count == 0)
            {
               ViewBag.Message = $"There is no service containing the word {title} in their title. ";
                var nullTitle = "";
               services = _service.GetServicesByTitle(nullTitle);
            }

            var servicesOverview = new List<LawServiceCardModel>();
            foreach (var service in services)
            {
                var modelService = service.ToLawServiceCardModel();
                servicesOverview.Add(modelService);
            }
            return View(servicesOverview);
        }

        public IActionResult ArticleDetails(int id)
        {
            try
            {
                var article = _service.GetArticleById(id);
                if (article == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(article.ToArticleDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
        public IActionResult CollaboratorsDetails(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorById(id);

                if (collaborator == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(collaborator.ToCollaboratorsDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
        public IActionResult LawServiceDetails(int id)
        {
            try
            {
                var service = _service.GetLawServicesById(id);

                if (service == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(service.ToLawServiceDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        public IActionResult AdminDetails(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorById(id);

                if (collaborator == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(collaborator.ToAdminDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
    }
}
