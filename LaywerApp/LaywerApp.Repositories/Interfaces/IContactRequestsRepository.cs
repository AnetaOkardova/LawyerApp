using LaywerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Repositories.Interfaces
{
    public interface IContactRequestsRepository
    {
        List<ContactRequest> GetByName(string name);
        List<ContactRequest> GetAll();
        ContactRequest GetById(int id);
        void Add(ContactRequest contactRequest);
    }
}
