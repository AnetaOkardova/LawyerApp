using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaywerApp.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Email { get; set; }
        [Required]
        public DateTime DateSent { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
