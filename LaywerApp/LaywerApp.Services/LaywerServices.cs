using LaywerApp.Common;
using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using LaywerApp.Services.DtoModels;
using LaywerApp.Services.Interfaces;
using System;
using System.Collections.Generic;


namespace LaywerApp.Services
{
    public class LaywerServices : ILaywerServices
    {
        private IContactRequestsRepository _contactRequestsRepository { get; set; }
        public LaywerServices(IContactRequestsRepository contactRequestsRepository)
        {
            _contactRequestsRepository = contactRequestsRepository;
        }

        //public Article GetArticleWithDetails(int id)
        //{
        //    var article = GetArticleById(id);
        //    if (article == null)
        //    {
        //        return article;
        //    }
        //    article.Views++;
        //    _articlesRepository.Update(article);
        //    return article;
        //}
       
        public void CreateRequest(ContactRequest contactRequest)
        {
            _contactRequestsRepository.Add(contactRequest);
        }
    }
}