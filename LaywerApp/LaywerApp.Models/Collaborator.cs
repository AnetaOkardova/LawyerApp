using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaywerApp.Models
{
    public class Collaborator
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string NameInLatin { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string LastNameInLatin { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Status { get; set; }
        [Required]
        [StringLength(maximumLength: 2000, MinimumLength = 3)]
        public string About { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsAdmin { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Views { get; set; }

    }
}
