using LaywerApp.Models;
using LaywerApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaywerApp.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private LaywerAppDbContext _context { get; set; }
        public ArticlesRepository(LaywerAppDbContext context)
        {
            _context = context;
        }

        public List<Article> GetByTitle(string title)
        {
            return _context.Articles.Where(x => x.Title.Contains(title)).ToList();
        }

        public List<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
