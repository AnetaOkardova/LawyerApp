using LaywerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Repositories
{
    public class LaywerAppDbContext : DbContext
    {
        public LaywerAppDbContext(DbContextOptions<LaywerAppDbContext> options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }
    }
}
