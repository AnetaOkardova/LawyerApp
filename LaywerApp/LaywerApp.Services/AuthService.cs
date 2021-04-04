using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using LaywerApp.Services.DtoModels;
using LaywerApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LaywerApp.Services
{
    public class AuthService : IAuthService
    {
        private ICollaboratorsRepository _collaboratorsRepository { get; set; }

        public AuthService(ICollaboratorsRepository collaboratorsRepository)
        {
            _collaboratorsRepository = collaboratorsRepository;
        }

        public StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var collaborator = _collaboratorsRepository.GetByUsername(username);

            if (collaborator != null && BCrypt.Net.BCrypt.Verify(password, collaborator.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", collaborator.Id.ToString()),
                    new Claim("Username", collaborator.Username),
                    new Claim("IsAdmin", collaborator.IsAdmin.ToString()),
                    new Claim("Email", collaborator.Email),
                };
                //create licna karta
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //create user
                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = isPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();

                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = $"The username or password is incorrect.";
            }
            return response;
        }

        public StatusModel SignUp(Collaborator collaborator)
        {
            var response = new StatusModel();
            var exist = _collaboratorsRepository.CheckIfExists(collaborator.Username, collaborator.Email);
            if (exist)
            {
                response.Success = false;
                response.Message = "This username has alredy been taken. Please try with another username.";
            }
            else
            {
                var newCollaborator = new Collaborator()
                {
                    Username = collaborator.Username,
                    Name = collaborator.Name,
                    NameInLatin = collaborator.NameInLatin,

                    LastName = collaborator.LastName,
                    LastNameInLatin = collaborator.LastNameInLatin,

                    Password = BCrypt.Net.BCrypt.HashPassword(collaborator.Password),
                    Email = collaborator.Email,
                    Status = collaborator.Status,
                    About = collaborator.About,
                    ImageUrl = collaborator.ImageUrl,
                    //DateCreated = DateTime.Now,
                };
                _collaboratorsRepository.Add(newCollaborator);
                response.Success = true;
            }
            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }
    }
}
