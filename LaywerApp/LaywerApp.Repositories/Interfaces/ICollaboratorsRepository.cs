using LaywerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Repositories.Interfaces
{
    public interface ICollaboratorsRepository
    {
        List<Collaborator> GetByName(string name);
        List<Collaborator> GetAll();
        Collaborator GetById(int id);
        void Add(Collaborator collaborator);
        void Delete(Collaborator collaborator);
    }
}
