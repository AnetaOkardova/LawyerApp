using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class ArticleDetailsModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public string Source { get; set; }
    }
}
