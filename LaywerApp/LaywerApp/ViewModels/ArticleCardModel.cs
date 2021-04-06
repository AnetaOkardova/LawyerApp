using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class ArticleCardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int Views { get; set; }
    }
}
