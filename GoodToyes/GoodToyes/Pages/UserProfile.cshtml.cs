using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Data;
using GoodToyes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private GoodToyesDbContext _context;

        public UserProfileModel(GoodToyesDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}