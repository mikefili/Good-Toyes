using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Data;
using GoodToyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages.User
{
    public class OrderHistoryModel : PageModel
    {
        private OrderService _orderService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private GoodToyesDbContext _context;

        public OrderHistoryModel(GoodToyesDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, OrderService orderService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _orderService = orderService;
        }

        public void OnGet()
        {
        }
    }
}