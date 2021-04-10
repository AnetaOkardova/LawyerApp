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
        private readonly ILawServicesService _lawServicesService;
        private readonly ICollaboratorsService _collaboratorsService;
        private readonly IArticlesService _articlesService;
        //private ILaywerServices _service { get; set; }
        public EditController( ILawServicesService lawServicesService, ICollaboratorsService collaboratorsService, IArticlesService articlesService)
        {
            //_service = service;
            _lawServicesService = lawServicesService;
            _collaboratorsService = collaboratorsService;
            _articlesService = articlesService;
        }

        public IActionResult EditOverview(string title, string name, string serviceTitle, string successMessage, string errorMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
            var id = int.Parse(User.FindFirst("Id").Value);
            var collaborators = _collaboratorsService.GetCollaboratorsByName(name);
            var collaboratorsToModify = collaborators.Where(x => x.Id != id).ToList();
            //put this method in Articles Service
            var articles = _articlesService.GetArticlesByTitle(title);
            var lawServices = _lawServicesService.GetServicesByTitle(serviceTitle);

            var articlesAndCollaborators = new ArticlesCollaboratorsLawServices();
            articlesAndCollaborators.Articles = articles;
            articlesAndCollaborators.Collaborators = collaboratorsToModify;
            articlesAndCollaborators.LawServices = lawServices;

            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;

            return View(articlesAndCollaborators);
        }
        
    }
}
