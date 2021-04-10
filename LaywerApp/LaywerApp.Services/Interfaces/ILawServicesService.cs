using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface ILawServicesService
    {
        void CreateLawService(LawService lawService);
        StatusModel DeleteLawService(int id);
        LawService GetLawServicesById(int id);
        StatusModel UpdateLawService(LawService lawService);
        List<LawService> GetServicesByTitle(string title);
        LawService GetLawServiceWithDetails(int id);
    }
}
