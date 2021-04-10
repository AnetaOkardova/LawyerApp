using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface IArticlesService
    {
        void CreateArticle(Article article);
        StatusModel DeleteArticle(int id);
        Article GetArticleById(int id);
        StatusModel UpdateArticle(Article domainModel);
        Article GetArticleWithDetails(int id);
        List<Article> GetArticlesByTitle(string title);
    }
}
