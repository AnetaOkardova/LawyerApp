using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;



namespace LaywerApp.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext);
        StatusModel SignUp(Collaborator collaborator);
        void SignOut(HttpContext httpContext);
    }
}
