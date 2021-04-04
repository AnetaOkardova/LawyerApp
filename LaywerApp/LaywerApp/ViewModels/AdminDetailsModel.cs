using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class AdminDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameInLatin { get; set; }

        public string LastName { get; set; }
        public string LastNameInLatin { get; set; }

        public string Status { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
    }
}
