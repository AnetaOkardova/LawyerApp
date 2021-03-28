using LaywerApp.Models;
using LaywerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Mappings
{
    public static class ViewModelExtensions
    {
        public static Article ToModel(this CreateArticleModel article)
        {
            return new Article()
            {
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Text = article.Text,
                ImageUrl = article.ImageUrl,
                Source = article.Source
            };
        }
        public static Collaborator ToModel(this CreateCollaboratorModel collaborator)
        {
            return new Collaborator()
            {
                Name = collaborator.Name,
                LastName = collaborator.LastName,
                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                Status = collaborator.Status,
                About = collaborator.About
            };
        }
        public static LawService ToModel(this CreateLawServiceModel service)
        {
            return new LawService()
            {
                Title = service.Title,
                Text = service.Text,
                ImageUrl = service.ImageUrl
            };
        }
        

        public static Article ToModel(this UpdateArticleModel article)
        {
            return new Article()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Text = article.Text,
                ImageUrl = article.ImageUrl,
                Source = article.Source
            };
        }
        public static Collaborator ToModel(this UpdateCollaboratorModel collaborator)
        {
            return new Collaborator()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                LastName = collaborator.LastName,
                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                Status = collaborator.Status,
                About = collaborator.About
            };
        }
        public static LawService ToModel(this UpdateLawServiceModel service)
        {
            return new LawService()
            {
                Id = service.Id,
                Title = service.Title,
                Text = service.Text,
                ImageUrl = service.ImageUrl,
            };
        }
    }
}
