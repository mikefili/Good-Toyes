using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models.Interfaces;
using GoodToyes.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodToyes.Models.Components
{
    public class CartVC : ViewComponent
    {
        private GoodToyesDbContext _context;

        public Cart(GoodToyesDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await _context.CartItems.OrderByDescending(ci => ci.ID).ToListAsync();
            return View(cartItems);
        }
    }
}
