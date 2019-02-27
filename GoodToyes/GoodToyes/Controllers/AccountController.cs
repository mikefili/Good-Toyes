using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using GoodToyes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _cart;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart cart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
        }
        
        /// <summary>
        /// User register Page
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Register() => View();

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {   //setting values to input from user
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthdate = rvm.Birthdate,
                    SpayedOrNeutered = rvm.SpayedOrNeutered
                };

                //creates passsword if password is in valid format
               var result = await _userManager.CreateAsync(user, rvm.Password);

                //creat a number of different claims
                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim spayOrNeuter = new Claim("SpayNeuter", $"{ user.SpayedOrNeutered }");

                    Claim birthdateClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    //list to hold the claims
                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdateClaim, emailClaim, spayOrNeuter };

                    //returns list of claims to user manager
                    await _userManager.AddClaimsAsync(user, claims);

                    //sends user to home page after sign in
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                
                
            }
            return View(rvm);
        }


        /// <summary>
        /// Logs user in and sends to home page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.TryAddModelError(string.Empty, "Invalid Login Attempt");

            return View(lvm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Index", "Home");
        }
    }
}
