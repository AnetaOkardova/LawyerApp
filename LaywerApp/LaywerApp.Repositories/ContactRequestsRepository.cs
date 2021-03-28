using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaywerApp.Repositories
{
    public class ContactRequestsRepository : IContactRequestsRepository
    {
        private LaywerAppDbContext _context { get; set; }
        public ContactRequestsRepository(LaywerAppDbContext context)
        {
            _context = context;
        }

        public List<ContactRequest> GetAll()
        {
            return _context.ContactRequests.ToList();
        }
        public ContactRequest GetById(int id)
        {
            return _context.ContactRequests.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactRequest> GetByName(string name)
        {
            return _context.ContactRequests.Where(x => x.Name.Contains(name)).ToList();
        }
        public void Add(ContactRequest contactRequest)
        {
            contactRequest.DateSent = DateTime.Now;
            _context.ContactRequests.Add(contactRequest);
            _context.SaveChanges();
        }
    }
}
