using GoodToyes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.ViewModels
{
    public class ApplicationUserViewModel
    {
        // properties
        public ApplicationUser AppUser { get; set; }
        public LoginViewModel LoginVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public CartItem CartItem { get; set; }

        // nav property
        public IEnumerable<Product> Products { get; set; }
    }
}
