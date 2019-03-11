using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models;
using GoodToyes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages.User
{
    public class UpdatePasswordModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Does Not Match")]
        public string ConfirmPassword { get; set; }

        public UpdatePasswordModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Updates the password
        /// </summary>
        /// <returns></returns>
        public async Task OnPostPassword()
        {
            var user = await _userManager.GetUserAsync(User);

            if (NewPassword == ConfirmPassword)
            {
                await _userManager.ChangePasswordAsync(user, Password, NewPassword);
            } 
        }

        /// <summary>
        /// Takes user to their dashboard
        /// </summary>
        /// <returns>A user</returns>
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
        }
    }
}