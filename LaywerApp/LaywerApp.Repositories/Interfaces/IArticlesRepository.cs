using LaywerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Repositories.Interfaces
{
    public interface IArticlesRepository
    {
        List<Article> GetByTitle(string title);
        List<Article> GetAll();
        Article GetById(int id);
        void Add(Article article);
    }
}
