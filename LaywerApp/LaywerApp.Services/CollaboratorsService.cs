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
    public class CollaboratorsService : ICollaboratorsService
    {
        private ICollaboratorsRepository _collaboratorsRepository { get; set; }

        public CollaboratorsService(ICollaboratorsRepository collaboratorsRepository)
        {
            _collaboratorsRepository = collaboratorsRepository;
        }
        public StatusModel CheckIfCorrectPassword(Collaborator collaborator, string currentPassword)
        {
            var response = new StatusModel();
            if (BCrypt.Net.BCrypt.Verify(currentPassword, collaborator.Password))
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Incorect current password";
            }
            return response;
        }

        public void CreateCollaborator(Collaborator collaborator)
        {
            _collaboratorsRepository.Add(collaborator);
        }

        public StatusModel DeleteCollaborator(int id)
        {
            var response = new StatusModel();

            var collaborator = _collaboratorsRepository.GetById(id);
            if (collaborator == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The item with ID {id} has been successfully deleted.";

                _collaboratorsRepository.Delete(collaborator);
            }
            return response;
        }

        public Collaborator GetCollaboratorById(int id)
        {
            var selectedCollaborator = _collaboratorsRepository.GetById(id);

            if (selectedCollaborator == null)
            {
                throw new LaywerAppException($"There is no collaborator with Id {id}.");
            }

            return selectedCollaborator;
        }

        public Collaborator GetCollaboratorWithDetails(int id)
        {
            var collaborator = GetCollaboratorById(id);
            if (collaborator == null)
            {
                return collaborator;
            }
            collaborator.Views++;
            _collaboratorsRepository.Update(collaborator);
            return collaborator;
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            var collaborator = _collaboratorsRepository.GetById(id);

            if (collaborator == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                collaborator.IsAdmin = !collaborator.IsAdmin;
                if (collaborator.IsAdmin)
                {
                    collaborator.Username = collaborator.NameInLatin[0] + "." + collaborator.LastNameInLatin;
                    collaborator.Password = "$2a$11$Dhv.M95aYbNgnvPPXiZZ6eGmg23a4U0HuOAohCtk7H2sH0zs8pp9m";
                }
                else
                {
                    collaborator.Username = null;
                    collaborator.Password = null;
                }

                _collaboratorsRepository.Update(collaborator);
                }

            return response;
            }

        public StatusModel UpdateAdminPassword(Collaborator collaborator)
        {
            var response = new StatusModel();
            var collaboratorToUpdate = _collaboratorsRepository.GetById(collaborator.Id);


            if (collaboratorToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The admin with ID {collaborator.Id} is not found.";
            }
            else
            {
                collaboratorToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(collaborator.Password);

                _collaboratorsRepository.Update(collaboratorToUpdate);

                response.Success = true;
                response.Message = "The password has been successfully updated.";
            }
            return response;
        }

        public StatusModel UpdateCollaborator(Collaborator collaborator)
        {
            var response = new StatusModel();
            var collaboratorToUpdate = _collaboratorsRepository.GetById(collaborator.Id);


            if (collaboratorToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The item with ID {collaborator.Id} is not found.";
            }
            else
            {
                collaboratorToUpdate.Name = collaborator.Name;
                collaboratorToUpdate.NameInLatin = collaborator.NameInLatin;

                collaboratorToUpdate.ImageUrl = collaborator.ImageUrl;
                collaboratorToUpdate.LastName = collaborator.LastName;
                collaboratorToUpdate.LastNameInLatin = collaborator.LastNameInLatin;

                collaboratorToUpdate.Email = collaborator.Email;
                collaboratorToUpdate.About = collaborator.About;
                collaboratorToUpdate.Status = collaborator.Status;
                collaboratorToUpdate.DateUpdated = DateTime.Now;

                _collaboratorsRepository.Update(collaboratorToUpdate);

                response.Success = true;
                response.Message = $"The item with ID {collaborator.Id} has been successfully updated.";
            }
            return response;
        }

        public List<Collaborator> GetCollaboratorsByName(string name)
        {
            if (name == null)
            {
                return _collaboratorsRepository.GetAll();
            }
            else
            {
                return _collaboratorsRepository.GetByName(name);
            }
        }
    }
}
