using LaywerApp.Common;
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
    public class LawServicesController : Controller
    {
        private readonly ILawServicesService _service;

        public LawServicesController(ILawServicesService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult CreateLawService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLawService(CreateLawServiceModel lawService)
        {
            var domainModel = lawService.ToModel();

            if (ModelState.IsValid)
            {
                _service.CreateLawService(domainModel);
                return RedirectToAction("EditOverview", "Edit");
            }
            return View(lawService);
        }
        public IActionResult DeleteLawService(int id)
        {
            var response = _service.DeleteLawService(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", "Edit", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("EditOverview", "Edit", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult UpdateLawService(int id)
        {
            try
            {
                var service = _service.GetLawServicesById(id);
                return View(service.ToUpdateLawServiceModel());
            }
            catch (LaywerAppException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpPost]
        public IActionResult UpdateLawService(UpdateLawServiceModel service)
        {
            var domainModel = service.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateLawService(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("EditOverview","Edit", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("EditOverview", "Edit", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(service);
            }
        }
        public IActionResult LawServiceOverview(string title)
        {
            var services = _service.GetServicesByTitle(title);

            if (services.Count == 0)
            {
                ViewBag.Message = $"There is no service containing the word {title} in their title. ";
                var nullTitle = "";
                services = _service.GetServicesByTitle(nullTitle);
            }

            var servicesOverview = new List<LawServiceCardModel>();
            foreach (var service in services)
            {
                var modelService = service.ToLawServiceCardModel();
                servicesOverview.Add(modelService);
            }
            return View(servicesOverview);
        }
        public IActionResult LawServiceDetails(int id)
        {
            try
            {
                var service = _service.GetLawServiceWithDetails(id);

                if (service == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(service.ToLawServiceDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
    }
}
