using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using LaywerApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace LaywerApp.Services
{
    public class LaywerServices : ILaywerServices
    {
        private IArticlesRepository _articlesRepository { get; set; }
        public LaywerServices(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
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
