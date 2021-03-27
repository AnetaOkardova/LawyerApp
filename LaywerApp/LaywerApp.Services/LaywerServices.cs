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
        private ILawServicesRepository _lawServicesRepository { get; set; }

        public LaywerServices(IArticlesRepository articlesRepository, ILawServicesRepository lawServicesRepository)
        {
            _articlesRepository = articlesRepository;
            _lawServicesRepository = lawServicesRepository;
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

        public Article GetArticleById(int id)
        {

            var selectedArticle = _articlesRepository.GetById(id);

            if(selectedArticle == null)
            {
                //implementiraj go ova
                throw new ArgumentNullException();
            }

            return selectedArticle;
        }

        public List<LawService> GetServicesByTitle(string title)
        {
            if (title == null)
            {
                return _lawServicesRepository.GetAll();
            }
            else
            {
                return _lawServicesRepository.GetByTitle(title);
            }
        }

        public LawService GetLawServicesById(int id)
        {

            var selectedService = _lawServicesRepository.GetById(id);

            if (selectedService == null)
            {
                //implementiraj go ova
                throw new ArgumentNullException();
            }

            return selectedService;
        }
    }
}
