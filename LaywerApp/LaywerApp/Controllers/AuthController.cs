using LaywerApp.Mappings;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _service { get; set; }
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel, string returnUrl)
        {

            var domainModel = signInModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignIn(domainModel.Username, domainModel.Password, signInModel.IsPersistent, HttpContext);
                if (response.Success)
                {
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Main", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }
            return View(signInModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            var domainModel = signUpModel.ToModel();
            if (ModelState.IsValid)
            {
                var response = _service.SignUp(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }

            return View(signUpModel);
        }
    }
}
