using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaywerApp.Models
{
    public class LawService
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int Views { get; set; }

    }
}
