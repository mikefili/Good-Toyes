using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models.ViewModels
{
    public class ExternalLoginViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Is Your Pet Spayed or Neutered?")]
        public bool SpayedOrNeutered { get; set; }
    }
}
