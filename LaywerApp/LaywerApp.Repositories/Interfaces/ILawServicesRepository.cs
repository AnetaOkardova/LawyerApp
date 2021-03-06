using LaywerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Repositories.Interfaces
{
    public interface ILawServicesRepository
    {
        List<LawService> GetByTitle(string title);
        List<LawService> GetAll();
        LawService GetById(int id);

        void Add(LawService lawService);
        void Delete(LawService service);
        void Update(LawService service);
    }
}
