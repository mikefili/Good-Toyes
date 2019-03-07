using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Data;
using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodToyes.Pages.User
{
    public class OrderHistoryModel : PageModel
    {
        private IOrder _orderService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private GoodToyesDbContext _context;

        public List<Order> Orders { get; set; }

        public OrderHistoryModel(GoodToyesDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOrder orderService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _orderService = orderService;
        }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            Orders = await _orderService.GetFiveOrders(user.Id);
        }
    }
}