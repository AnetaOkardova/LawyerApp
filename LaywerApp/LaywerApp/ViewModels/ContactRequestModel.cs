using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class ContactRequestModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
