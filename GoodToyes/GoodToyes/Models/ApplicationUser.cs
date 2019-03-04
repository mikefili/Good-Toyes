using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public bool SpayedOrNeutered { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }
}
