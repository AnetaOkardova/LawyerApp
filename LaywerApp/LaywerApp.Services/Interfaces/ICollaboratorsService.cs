using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface ICollaboratorsService
    {
        Collaborator GetCollaboratorWithDetails(int id);
        Collaborator GetCollaboratorById(int id);
        void CreateCollaborator(Collaborator collaborator);
        StatusModel DeleteCollaborator(int id);
        StatusModel UpdateCollaborator(Collaborator collaborator);
        StatusModel ToggleAdminRole(int id);
        StatusModel CheckIfCorrectPassword(Collaborator collaborator, string currentPassword);
        StatusModel UpdateAdminPassword(Collaborator collaborator);
        List<Collaborator> GetCollaboratorsByName(string name);
    }
}
