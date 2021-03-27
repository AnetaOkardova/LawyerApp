using LaywerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface ILaywerServices
    {
        List<Article> GetArticlesByTitle(string title);
        Article GetArticleById(int id);
        List<LawService> GetServicesByTitle(string title);
        LawService GetLawServicesById(int id);
        List<Collaborator> GetCollaboratorsByName(string name);
        Collaborator GetCollaboratorById(int id);
    }
}
