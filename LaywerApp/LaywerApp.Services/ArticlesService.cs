using LaywerApp.Common;
using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using LaywerApp.Services.DtoModels;
using LaywerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services
{
    public class ArticlesService : IArticlesService
    {
        private IArticlesRepository _articlesRepository { get; set; }

        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public void CreateArticle(Article article)
        {
            _articlesRepository.Add(article);
        }
        public StatusModel DeleteArticle(int id)
        {
            var response = new StatusModel();

            var article = _articlesRepository.GetById(id);
            if (article == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The item with ID {id} has been successfully deleted.";

                _articlesRepository.Delete(article);
            }
            return response;
        }
        public Article GetArticleById(int id)
        {
            var selectedArticle = _articlesRepository.GetById(id);

            if (selectedArticle == null)
            {
                throw new LaywerAppException($"There is no article with Id {id}.");
            }

            return selectedArticle;
        }
        public StatusModel UpdateArticle(Article article)
        {
            var response = new StatusModel();
            var articleToUpdate = _articlesRepository.GetById(article.Id);


            if (articleToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {article.Id} is not found.";
            }
            else
            {
                articleToUpdate.Title = article.Title;
                articleToUpdate.ImageUrl = article.ImageUrl;
                articleToUpdate.ShortDescription = article.ShortDescription;
                articleToUpdate.Source = article.Source;
                articleToUpdate.Text = article.Text;
                articleToUpdate.DateUpdated = DateTime.Now;

                _articlesRepository.Update(articleToUpdate);

                response.Success = true;
                response.Message = $"The item with ID {article.Id} has been successfully updated.";
            }
            return response;
        }

        public Article GetArticleWithDetails(int id)
        {
            var article = GetArticleById(id);
            if (article == null)
            {
                return article;
            }
            article.Views++;
            _articlesRepository.Update(article);
            return article;
        }

        public List<Article> GetArticlesByTitle(string title)
        {
            if (title == null)
            {
                return _articlesRepository.GetAll();
            }
            else
            {
                return _articlesRepository.GetByTitle(title);
            }
        }
    }
}
