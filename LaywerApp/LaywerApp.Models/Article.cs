using System;
using System.ComponentModel.DataAnnotations;

namespace LaywerApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 3)]
        public string ShortDescription { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Source { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int Views { get; set; }

    }
}
