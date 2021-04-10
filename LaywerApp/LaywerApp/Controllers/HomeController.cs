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
        private readonly ILawServicesService _lawServicesService;
        private readonly ICollaboratorsService _collaboratorsService;
        private readonly IArticlesService _articlesService;
        public HomeController(ILawServicesService lawServicesService, ICollaboratorsService collaboratorsService, IArticlesService articlesService)
        {
            _lawServicesService = lawServicesService;
            _collaboratorsService = collaboratorsService;
            _articlesService = articlesService;
        }

        public IActionResult Main(string title, string name, string serviceTitle)
        {
            var articles = _articlesService.GetArticlesByTitle(title);
            var newArticles = articles.Select(x => x.ToArticleCardModel()).ToList();
            //
            var collaborators = _collaboratorsService.GetCollaboratorsByName(name);
            var newCollaborators = collaborators.Select(x => x.ToCollaboratorCardModel()).ToList();

            var lawServices = _lawServicesService.GetServicesByTitle(serviceTitle);
            var newServices = lawServices.Select(x => x.ToLawServiceCardModel()).ToList();

            var overviewModel = new OverviewModel();
            overviewModel.Articles = newArticles;
            overviewModel.Collaborators = newCollaborators;
            overviewModel.LawServices = newServices;
            return View(overviewModel);
        }

    }
}
