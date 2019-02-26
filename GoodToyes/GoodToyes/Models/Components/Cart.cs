//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GoodToyes.Models.Components
//{
//    public class Cart : ViewComponent
//    {
//        private CartItems _context;

//        public Cart(CartItems context)
//        {
//            _context = context;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var cartItems = await _context.CartItems.OrderByDescending(ci => ci.ID).ToList();
//            return View(cartItems);
//        }
//    }
//}
