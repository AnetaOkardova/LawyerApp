using LaywerApp.Common;
using LaywerApp.Mappings;
using LaywerApp.Models;
using LaywerApp.Services.Interfaces;
using LaywerApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.Controllers
{
    public class CollaboratorsController : Controller
    {
        private readonly ICollaboratorsService _service;

        public CollaboratorsController(ICollaboratorsService service)
        {
            _service = service;
        }

        public IActionResult CollaboratorsDetails(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorWithDetails(id);

                if (collaborator == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(collaborator.ToCollaboratorsDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }
        public IActionResult AdminDetails(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorById(id);

                if (collaborator == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(collaborator.ToAdminDetailsModel());
            }
            catch (LaywerAppException)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

        }

        [HttpGet]
        public IActionResult CreateCollaborator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCollaborator(CreateCollaboratorModel collaborator)
        {
            var domainModel = collaborator.ToModel();

            if (ModelState.IsValid)
            {
                _service.CreateCollaborator(domainModel);
                return RedirectToAction("EditOverview", "Edit");
            }
            return View(collaborator);
        }

        public IActionResult DeleteCollaborator(int id)
        {
            var response = _service.DeleteCollaborator(id);
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
        public IActionResult UpdateCollaborator(int id)
        {
            try
            {
                var collaborator = _service.GetCollaboratorById(id);
                return View(collaborator.ToUpdateCollaboratorModel());
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
        public IActionResult UpdateCollaborator(UpdateCollaboratorModel collaborator)
        {
            var domainModel = collaborator.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateCollaborator(domainModel);
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
                return View(collaborator);
            }
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            try
            {

                var collaborator = _service.GetCollaboratorById(id);
                return View(collaborator.ToUpdateAdminModel());
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
        public IActionResult UpdateAdmin(UpdateAdminModel admin)
        {
            var domainModel = admin.ToModel();

            if (ModelState.IsValid)
            {
                var response = _service.UpdateCollaborator(domainModel);
                if (response.Success)
                {
                    return RedirectToAction("Main", "Home");
                }
                else
                {
                    return RedirectToAction("Main", "Home");
                }
            }
            else
            {
                return View(admin);
            }
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult ToggleAdminRole(int id)
        {
            var response = _service.ToggleAdminRole(id);
            if (response.Success)
            {
                return RedirectToAction("EditOverview", "Edit", new { SuccessMessage = "User updated successfully." });
            }
            else
            {
                return RedirectToAction("EditOverview", "Edit", new { ErrorMessage = response.Message });
            }
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel admin)
        {
            var domainModel = admin.ToModel();

            if (ModelState.IsValid)
            {
                var collaborator = _service.GetCollaboratorById(admin.Id);
                if (collaborator == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                var passwordIsvalid = _service.CheckIfCorrectPassword(collaborator, admin.CurrentPassword);
                if (passwordIsvalid.Success)
                {
                    _service.UpdateAdminPassword(domainModel);
                    return RedirectToAction("SignIn", "Auth");
                }
                else
                {
                    ViewBag.Message = passwordIsvalid.Message;
                    return View(admin);
                }
            }
            return View(admin);
        }
    }
}
