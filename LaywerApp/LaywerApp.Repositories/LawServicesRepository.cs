using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaywerApp.Repositories
{
    public class LawServicesRepository : ILawServicesRepository
    {
        private LaywerAppDbContext _context { get; set; }
        public LawServicesRepository(LaywerAppDbContext context)
        {
            _context = context;
        }

        public List<LawService> GetAll()
        {
            return _context.LawServices.ToList();
        }
        public LawService GetById(int id)
        {
            return _context.LawServices.FirstOrDefault(x => x.Id == id);
        }
        public List<LawService> GetByTitle(string title)
        {
            return _context.LawServices.Where(x => x.Title.Contains(title)).ToList();
        }

        public void Add(LawService lawService)
        {
            lawService.DateCreated = DateTime.Now;
            _context.LawServices.Add(lawService);
            _context.SaveChanges();
        }

        public void Delete(LawService service)
        {
            _context.LawServices.Remove(service);
            _context.SaveChanges();
        }
    }
}
