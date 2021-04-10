using LaywerApp.Common;
using LaywerApp.Mappings;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _service;

        public ArticlesController(IArticlesService service)
        {
            _service = service;
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
                return RedirectToAction("EditOverview", "Edit");
            }
            return View(article);
        }

        public IActionResult DeleteArticle(int id)
        {
            var response = _service.DeleteArticle(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", "Edit", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("EditOverview", "Edit", new { ErrorMessage = response.Message });
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
                    return RedirectToAction("EditOverview", "Edit", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("EditOverview", "Edit", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(article);
            }
        }

        public IActionResult ArticleDetails(int id)
        {
            try
            {
                var article = _service.GetArticleWithDetails(id);
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
    }
}
