using LaywerApp.Models;
using LaywerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Mappings
{
    public static class DomainModelExtensions
    {
        public static UpdateArticleModel ToUpdateArticleModel(this Article article)
        {
            return new UpdateArticleModel()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Text = article.Text,
                ImageUrl = article.ImageUrl,
                Source = article.Source
            };
        }
        public static UpdateCollaboratorModel ToUpdateCollaboratorModel(this Collaborator collaborator)
        {
            return new UpdateCollaboratorModel()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                LastName = collaborator.LastName,
                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                About = collaborator.About,
                Status = collaborator.Status
            };
        }
        public static UpdateAdminModel ToUpdateAdminModel(this Collaborator collaborator)
        {
            return new UpdateAdminModel()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                LastName = collaborator.LastName,
                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                About = collaborator.About,
                Status = collaborator.Status
            };
        }
        public static UpdateLawServiceModel ToUpdateLawServiceModel(this LawService service)
        {
            return new UpdateLawServiceModel()
            {
                Id = service.Id,
                Title = service.Title,
                ImageUrl = service.ImageUrl,
                Text = service.Text
            };
        }

        public static ArticleDetailsModel ToArticleDetailsModel(this Article article)
        {
            return new ArticleDetailsModel()
            {
                Title = article.Title,
                Text = article.Text,
                ImageUrl = article.ImageUrl,
                Source = article.Source,
                DateCreated = article.DateCreated
            };
        }
        public static CollaboratorsDetailsModel ToCollaboratorsDetailsModel(this Collaborator collaborator)
        {
            return new CollaboratorsDetailsModel()
            {
                Name = collaborator.Name,
                LastName = collaborator.LastName,
                About = collaborator.About,
                Status = collaborator.Status,
                ImageUrl = collaborator.ImageUrl,
                Email = collaborator.Email,
            };
        }
        public static LawServiceDetailsModel ToLawServiceDetailsModel(this LawService service)
        {
            return new LawServiceDetailsModel()
            {
                Title = service.Title,
                Text = service.Text,
                DateCreated = service.DateCreated,
                ImageUrl = service.ImageUrl,
            };
        }

        public static AdminDetailsModel ToAdminDetailsModel(this Collaborator collaborator)
        {
            return new AdminDetailsModel()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                NameInLatin = collaborator.NameInLatin,
                LastName = collaborator.LastName,
                LastNameInLatin = collaborator.LastNameInLatin,
                About = collaborator.About,
                Status = collaborator.Status,
                ImageUrl = collaborator.ImageUrl,
                Email = collaborator.Email,
            };
        }

        public static LawServiceCardModel ToLawServiceCardModel(this LawService service)
        {
            return new LawServiceCardModel()
            {
                Id = service.Id,
                Title = service.Title,
                ImageUrl = service.ImageUrl,
                Views = service.Views
            };
        }
        public static CollaboratorCardModel ToCollaboratorCardModel(this Collaborator collaborator)
        {
            return new CollaboratorCardModel()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                NameInLatin = collaborator.NameInLatin,
                LastName = collaborator.LastName,
                LastNameInLatin = collaborator.LastNameInLatin,
                Status = collaborator.Status,
                ImageUrl = collaborator.ImageUrl,
                About = collaborator.About,
                Views = collaborator.Views
            };
        }
        public static ArticleCardModel ToArticleCardModel(this Article article)
        {
            return new ArticleCardModel()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                ImageUrl = article.ImageUrl,
                DateCreated = article.DateCreated,
                Views = article.Views
            };
        }
    }
}