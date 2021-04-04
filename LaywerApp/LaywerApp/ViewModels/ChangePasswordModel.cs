using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaywerApp.ViewModels
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string CurrentPassword { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
