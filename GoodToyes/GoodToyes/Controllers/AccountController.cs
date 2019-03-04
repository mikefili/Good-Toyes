using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using GoodToyes.Models.ViewModels;
using GoodToyes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _cart;
        private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart cart, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
            _emailSender = emailSender;
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
                    StreetAddress = rvm.StreetAddress,
                    City = rvm.City,
                    Zip = rvm.Zip,
                    SpayedOrNeutered = rvm.SpayedOrNeutered
                };

                //creates passsword if password is in valid format
                var result = await _userManager.CreateAsync(user, rvm.Password);

                //creat a number of different claims
                if (result.Succeeded)
                {
                    await _cart.CreateCart(user);
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim spayOrNeuter = new Claim("SpayNeuter", $"{ user.SpayedOrNeutered }");

                    Claim birthdateClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    //list to hold the claims
                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdateClaim, emailClaim, spayOrNeuter };

                    //returns list of claims to user manager
                    await _userManager.AddClaimsAsync(user, claims);

                    //send user confirmation email


                    //sends user to home page after sign in
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    RegistrationEmail(user);
                    return RedirectToAction("Index", "Home");
                }            
            }
            return View(rvm);
        }

        /// <summary>
        /// Sends registration confirmation email to user
        /// </summary>
        /// <param name="user">User registering</param>
        public async void RegistrationEmail(ApplicationUser user)
        {
            ApplicationUser thisUser = await _userManager.FindByEmailAsync(user.Email);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"<h1 align='center'>Hey {thisUser.FirstName}, thanks for registering with Good Toyes!</h1>");
            sb.AppendLine("<p align='center'>We hope you and your good boye have a good day!</p>");

            await _emailSender.SendEmailAsync(thisUser.Email, "Registration Confirmation", sb.ToString());
        }

        /// <summary>
        /// Logs user in and sends to home page
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// Validates password to log in user
        /// </summary>
        /// <param name="lvm">Login view model</param>
        /// <returns>Signed in home index view</returns>
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

        /// <summary>
        /// Logs user out
        /// </summary>
        /// <returns>view</returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Logs user in using external authentication
        /// </summary>
        /// <param name="provider"></param>
        /// <returns>Provider</returns>
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallBack), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        /// <summary>
        /// Gets user info back from external login provider
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallBack(string error = null)
        {
            // Send user away on error message
            if (error != null)
            {
                // Log incoming error code
                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }

            // Check if app supports login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();

            // If provider not supported, redirect to alternate login method
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Login with external provider
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            // Redirect user home if login successful
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            // Get user's email if initial login
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            // Redirect to external login proivder to allow user to login
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        }


        /// <summary>
        /// Confirms that user has been logged in with external provider
        /// </summary>
        /// <param name="elvm"></param>
        /// <returns>view</returns>
        public async Task<IActionResult> ExternalLoginConfimation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error Loading Information";
                }

                // Create user
                var user = new ApplicationUser { UserName = elvm.Email, Email = elvm.Email, FirstName = elvm.FirstName, LastName = elvm.LastName, SpayedOrNeutered = elvm.SpayedOrNeutered };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        await _cart.CreateCart(user);
                        Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                        Claim spayOrNeuter = new Claim("SpayNeuter", $"{ user.SpayedOrNeutered }");

                        Claim birthdateClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                            ClaimValueTypes.DateTime);

                        Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                        //list to hold the claims
                        List<Claim> claims = new List<Claim> { fullNameClaim, birthdateClaim, emailClaim, spayOrNeuter };

                        //returns list of claims to user manager
                        await _userManager.AddClaimsAsync(user, claims);

                        // Sign in user with info from provider
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("Login");
        }
    }
}
