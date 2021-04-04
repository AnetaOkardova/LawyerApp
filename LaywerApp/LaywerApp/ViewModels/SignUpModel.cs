using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class SignUpModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string NameInLatin { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LastNameInLatin { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Status { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
