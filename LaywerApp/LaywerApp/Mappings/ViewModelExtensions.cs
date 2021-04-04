﻿using LaywerApp.Models;
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
        public static ContactRequest ToModel(this ContactRequestModel request)
        {
            return new ContactRequest()
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Message = request.Message
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

        //public static LawService ToModel(this LawServiceCardModel service)
        //{
        //    return new LawService()
        //    {
        //        Id = service.Id,
        //        Title = service.Title,
        //        ImageUrl = service.ImageUrl,
        //    };
        //}
        //public static Collaborator ToModel(this CollaboratorCardModel collaborator)
        //{
        //    return new Collaborator()
        //    {
        //        Id = collaborator.Id,
        //        Name = collaborator.Name,
        //        LastName = collaborator.LastName,
        //        Status = collaborator.Status,
        //        ImageUrl = collaborator.ImageUrl,
        //        About = collaborator.About
        //    };
        //}
        //public static Article ToModel(this ArticleCardModel article)
        //{
        //    return new Article()
        //    {
        //        Id = article.Id,
        //        Title = article.Title,
        //        ShortDescription = article.ShortDescription,
        //        ImageUrl = article.ImageUrl,
        //    };
        //}
    }
}