using LaywerApp.Common;
using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using LaywerApp.Services.DtoModels;
using LaywerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services
{
    public class LawServicesService : ILawServicesService
    {
        private ILawServicesRepository _lawServicesRepository { get; set; }

        public LawServicesService(ILawServicesRepository lawServicesRepository)
        {
            _lawServicesRepository = lawServicesRepository;
        }

        public void CreateLawService(LawService lawService)
        {
            _lawServicesRepository.Add(lawService);
        }
        public StatusModel DeleteLawService(int id)
        {
            var response = new StatusModel();

            var service = _lawServicesRepository.GetById(id);
            if (service == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The item with ID {id} has been successfully deleted.";

                _lawServicesRepository.Delete(service);
            }
            return response;
        }
        public StatusModel UpdateLawService(LawService service)
        {
            var response = new StatusModel();
            var serviceToUpdate = _lawServicesRepository.GetById(service.Id);


            if (serviceToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {service.Id} is not found.";
            }
            else
            {
                serviceToUpdate.Title = service.Title;
                serviceToUpdate.ImageUrl = service.ImageUrl;
                serviceToUpdate.Text = service.Text;
                serviceToUpdate.DateUpdated = DateTime.Now;

                _lawServicesRepository.Update(serviceToUpdate);

                response.Success = true;
                response.Message = $"The item with ID {service.Id} has been successfully updated.";
            }
            return response;
        }
        public LawService GetLawServicesById(int id)
        {
            var selectedService = _lawServicesRepository.GetById(id);

            if (selectedService == null)
            {
                throw new LaywerAppException($"There is no service with Id {id}.");
            }

            return selectedService;
        }
        public List<LawService> GetServicesByTitle(string title)
        {
            if (title == null)
            {
                return _lawServicesRepository.GetAll();
            }
            else
            {
                return _lawServicesRepository.GetByTitle(title);
            }
        }
        public LawService GetLawServiceWithDetails(int id)
        {
            var service = GetLawServicesById(id);
            if (service == null)
            {
                return service;
            }
            service.Views++;
            _lawServicesRepository.Update(service);
            return service;
        }
    }
}
