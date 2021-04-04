using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string CurentPassword { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string NewPassword { get; set; }
        //[Required]
        //[StringLength(maximumLength: 50, MinimumLength = 8)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
