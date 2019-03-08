using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages.User
{
    public class UpdatePasswordModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UpdatePasswordModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
        }
    }
}