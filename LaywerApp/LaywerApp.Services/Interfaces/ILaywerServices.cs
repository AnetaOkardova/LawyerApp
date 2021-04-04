using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface ILaywerServices
    {
        List<Article> GetArticlesByTitle(string title);
        Article GetArticleById(int id);
        void CreateArticle(Article article);
        StatusModel DeleteArticle(int id);

        List<LawService> GetServicesByTitle(string title);
        LawService GetLawServicesById(int id);
        void CreateLawService(LawService lawService);
        StatusModel DeleteLawService(int id);

        List<Collaborator> GetCollaboratorsByName(string name);
        Collaborator GetCollaboratorById(int id);
        void CreateCollaborator(Collaborator collaborator);
        StatusModel DeleteCollaborator(int id);


        void CreateRequest(ContactRequest contactRequest);

        StatusModel UpdateArticle(Article article);
        StatusModel UpdateLawService(LawService service);
        StatusModel UpdateCollaborator(Collaborator collaborator);
        StatusModel ToggleAdminRole(int id);
        StatusModel UpdateAdminPassword(Collaborator domainModel);
    }
}
