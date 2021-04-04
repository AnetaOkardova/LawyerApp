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
                throw new LaywerAppException($"There is no article with Id {id}.");
            }

            return selectedArticle;
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
                throw new LaywerAppException($"There is no service with Id {id}.");
            }

            return selectedService;
        }
        public void CreateLawService(LawService lawService)
        {
            _lawServicesRepository.Add(lawService);
        }
        public StatusModel DeleteLawService(int id)
        {
            var response = new StatusModel();

            var service = _lawServicesRepository.GetById(id);
            if (service == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The item with ID {id} has been successfully deleted.";

                _lawServicesRepository.Delete(service);
            }
            return response;
        }
        public StatusModel UpdateLawService(LawService service)
        {
            var response = new StatusModel();
            var serviceToUpdate = _lawServicesRepository.GetById(service.Id);


            if (serviceToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {service.Id} is not found.";
            }
            else
            {
                serviceToUpdate.Title = service.Title;
                serviceToUpdate.ImageUrl = service.ImageUrl;
                serviceToUpdate.Text = service.Text;
                serviceToUpdate.DateUpdated = DateTime.Now;

                _lawServicesRepository.Update(serviceToUpdate);

                response.Success = true;
                response.Message = $"The item with ID {service.Id} has been successfully updated.";
            }
            return response;
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
                throw new LaywerAppException($"There is no collaborator with Id {id}.");
            }

            return selectedCollaborator;
        }
        public void CreateCollaborator(Collaborator collaborator)
        {
            _collaboratorsRepository.Add(collaborator);
        }
        public StatusModel DeleteCollaborator(int id)
        {
            var response = new StatusModel();

            var collaborator = _collaboratorsRepository.GetById(id);
            if (collaborator == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The item with ID {id} has been successfully deleted.";

                _collaboratorsRepository.Delete(collaborator);
            }
            return response;
        }
        public StatusModel UpdateCollaborator(Collaborator collaborator)
        {
            var response = new StatusModel();
            var collaboratorToUpdate = _collaboratorsRepository.GetById(collaborator.Id);


            if (collaboratorToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {collaborator.Id} is not found.";
            }
            else
            {
                collaboratorToUpdate.Name = collaborator.Name;
                collaboratorToUpdate.NameInLatin = collaborator.NameInLatin;

                collaboratorToUpdate.ImageUrl = collaborator.ImageUrl;
                collaboratorToUpdate.LastName = collaborator.LastName;
                collaboratorToUpdate.LastNameInLatin = collaborator.LastNameInLatin;

                collaboratorToUpdate.Email = collaborator.Email;
                collaboratorToUpdate.About = collaborator.About;
                collaboratorToUpdate.Status = collaborator.Status;
                collaboratorToUpdate.DateUpdated = DateTime.Now;

                _collaboratorsRepository.Update(collaboratorToUpdate);

                response.Success = true;
                response.Message = $"The item with ID {collaborator.Id} has been successfully updated.";
            }
            return response;
        }

        public void CreateRequest(ContactRequest contactRequest)
        {
            _contactRequestsRepository.Add(contactRequest);
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            var collaborator = _collaboratorsRepository.GetById(id);
            
            if (collaborator == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                collaborator.IsAdmin = !collaborator.IsAdmin;
                if (collaborator.IsAdmin)
                {
                    collaborator.Username = collaborator.NameInLatin[0] + "." + collaborator.LastNameInLatin;
                    collaborator.Password = "$2a$11$Dhv.M95aYbNgnvPPXiZZ6eGmg23a4U0HuOAohCtk7H2sH0zs8pp9m";
                }
                else
                {
                    collaborator.Username = null;
                    collaborator.Password = null;
                }
                
                _collaboratorsRepository.Update(collaborator);
            }

            return response;
        }

        public StatusModel UpdateAdminPassword(Collaborator collaborator)
        {
            var response = new StatusModel();
            var collaboratorToUpdate = _collaboratorsRepository.GetById(collaborator.Id);


            if (collaboratorToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The admin with ID {collaborator.Id} is not found.";
            }
            else
            {
                collaboratorToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(collaborator.Password);

                _collaboratorsRepository.Update(collaboratorToUpdate);

                response.Success = true;
                response.Message = "The password has been successfully updated.";
            }
            return response;
        }
    }
}
