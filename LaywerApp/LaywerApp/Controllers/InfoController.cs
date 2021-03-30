using LaywerApp.Mappings;
using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class InfoController : Controller
    {
        private ILaywerServices _service { get; set; }
        public InfoController (ILaywerServices service)
        {
            _service = service;
        }
        public IActionResult ErrorNotFound()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(ContactRequestModel contactRequest)
        {
            if (ModelState.IsValid)
            {
                _service.CreateRequest(contactRequest.ToModel());
                return RedirectToAction("Main", "Home");
            }
            return View(contactRequest);
        }
        public IActionResult ActionNotSuccessful(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        
    }
}
