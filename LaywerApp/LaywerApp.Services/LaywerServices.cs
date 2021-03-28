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
        private ICollaboratorsRepository _collaboratorsRepository { get; set; }
        private IContactRequestsRepository _contactRequestsRepository { get; set; }

        public LaywerServices(IArticlesRepository articlesRepository, ILawServicesRepository lawServicesRepository, ICollaboratorsRepository collaboratorsRepository, IContactRequestsRepository contactRequestsRepository)
        {
            _articlesRepository = articlesRepository;
            _lawServicesRepository = lawServicesRepository;
            _collaboratorsRepository = collaboratorsRepository;
            _contactRequestsRepository = contactRequestsRepository;
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

            if (selectedArticle == null)
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
        public List<Collaborator> GetCollaboratorsByName(string name)
        {
            if (name == null)
            {
                return _collaboratorsRepository.GetAll();
            }
            else
            {
                return _collaboratorsRepository.GetByName(name);
            }
        }
        public Collaborator GetCollaboratorById(int id)
        {
            var selectedCollaborator = _collaboratorsRepository.GetById(id);

            if (selectedCollaborator == null)
            {
                //implementiraj go ova
                throw new ArgumentNullException();
            }

            return selectedCollaborator;
        }
        public void CreateRequest(ContactRequest contactRequest)
        {
            _contactRequestsRepository.Add(contactRequest);
        }
    }
}
