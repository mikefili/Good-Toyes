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
    public class UserProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private GoodToyesDbContext _context;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool SpayedOrNeutered { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Constructor takes in all necessary context of user profile
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="signInManager">Sign in manager interface</param>
        /// <param name="userManager">User manager interface</param>
        public UserProfileModel(GoodToyesDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Updates specific user info fields
        /// </summary>
        /// <param name="firstName">User input for first name property</param>
        /// <param name="lastName">User input for last name property</param>
        /// <param name="streetAddress">User input for street address property</param>
        /// <param name="city">User input for city property</param>
        /// <param name="state">User input for city property</param>
        /// <param name="zip">User input for zip code property</param>
        /// <returns>Update task which updates the user's profile</returns>
        public async Task OnPostUpdate(string firstName, string lastName, DateTime birthDate, string streetAddress, string city, string state, string zip)
        {
            var user = await _userManager.GetUserAsync(User);

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Birthdate = birthDate;
            user.StreetAddress = streetAddress;
            user.City = city;
            user.State = state;
            user.Zip = zip;

            await _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// Get user information using UserManager interface
        /// </summary>
        /// <returns>Brings all user info in for use</returns>
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Birthdate = user.Birthdate;
            StreetAddress = user.StreetAddress;
            City = user.City;
            State = user.State;
            Zip = user.Zip;
            SpayedOrNeutered = user.SpayedOrNeutered;
        }
    }
}