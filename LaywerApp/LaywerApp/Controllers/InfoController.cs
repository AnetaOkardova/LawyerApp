﻿using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
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
        public IActionResult ContactUs(ContactRequest contactRequest)
        {
            if (ModelState.IsValid)
            {
                _service.CreateRequest(contactRequest);
                return RedirectToAction("Home", "Main");
            }
            return View(contactRequest);
        }
    }
}
