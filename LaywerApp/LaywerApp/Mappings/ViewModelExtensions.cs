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
                NameInLatin = collaborator.NameInLatin,

                LastName = collaborator.LastName,
                LastNameInLatin = collaborator.LastNameInLatin,

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
                NameInLatin = collaborator.NameInLatin,

                LastName = collaborator.LastName,
                LastNameInLatin = collaborator.LastNameInLatin,

                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                Status = collaborator.Status,
                About = collaborator.About
            };
        }
        public static Collaborator ToModel(this UpdateAdminModel collaborator)
        {
            return new Collaborator()
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                NameInLatin = collaborator.NameInLatin,

                LastName = collaborator.LastName,
                LastNameInLatin = collaborator.LastNameInLatin,

                Email = collaborator.Email,
                ImageUrl = collaborator.ImageUrl,
                Status = collaborator.Status,
                About = collaborator.About
            };
        }
        public static Collaborator ToModel(this ChangePasswordModel admin)
        {
            return new Collaborator()
            {
                Id = admin.Id,
                Password = admin.NewPassword,
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

        public static Collaborator ToModel(this SignInModel signInModel)
        {
            return new Collaborator()
            {
                Id =signInModel.Id,
                Username = signInModel.Username,
                Password = signInModel.Password,
            };
        }
        public static Collaborator ToModel(this SignUpModel signUpModel)
        {
            return new Collaborator()
            {
                Username = signUpModel.Username,
                Password = signUpModel.Password,
                Name = signUpModel.Name,
                NameInLatin = signUpModel.NameInLatin,

                LastName = signUpModel.LastName,
                LastNameInLatin = signUpModel.LastNameInLatin,

                Email = signUpModel.Email,
                About = signUpModel.About,
                ImageUrl = signUpModel.ImageUrl,
                Status = signUpModel.Status
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
