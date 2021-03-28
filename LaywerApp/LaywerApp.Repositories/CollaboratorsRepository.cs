using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaywerApp.Repositories
{
    public class CollaboratorsRepository : ICollaboratorsRepository
    {
        private LaywerAppDbContext _context { get; set; }
        public CollaboratorsRepository(LaywerAppDbContext context)
        {
            _context = context;
        }

        public List<Collaborator> GetAll()
        {
            return _context.Collaborators.ToList();
        }
        public Collaborator GetById(int id)
        {
            return _context.Collaborators.FirstOrDefault(x => x.Id == id);

        }
        public List<Collaborator> GetByName(string name)
        {
            return _context.Collaborators.Where(x => x.Name.Contains(name)).ToList();
        }
        public void Add(Collaborator collaborator)
        {
            _context.Collaborators.Add(collaborator);
            _context.SaveChanges();
        }
    }
}
