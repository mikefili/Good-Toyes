using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models.Interfaces;
using GoodToyes.Data;
using Microsoft.EntityFrameworkCore;
using GoodToyes.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GoodToyes.Models.Components
{
    public class CartVC : ViewComponent
    {
        private GoodToyesDbContext _context;
        private ICart _cart;
        private IProduct _product;
        private UserManager<ApplicationUser> _userManager;

        public CartVC(GoodToyesDbContext context, ICart cart, IProduct product, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _cart = cart;
            _product = product;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userEmail = User.Identity.Name;

            if (userEmail == null)
            {
                return View();
            }

            var ourUser = await _userManager.FindByEmailAsync(userEmail);
            string user = ourUser.Id;
            var userCart = await _cart.GetCart(user);
            var userItemsRaw = await _context.CartItems.OrderBy(ci => ci.ID).ToListAsync();
            var userItems = userItemsRaw.Where(u => u.CartID == userCart.ID);
            List<CartItemViewModel> cartItemVMList = new List<CartItemViewModel>();

            foreach (var item in userItems)
            {
                Product product = await _product.GetProduct(item.ProductID);
                CartItemViewModel cartItemVM = new CartItemViewModel();
                cartItemVM.ProductName = product.Name;
                cartItemVM.ProductPrice = product.Price;
                cartItemVMList.Add(cartItemVM);
            }

            return View(cartItemVMList);
        }
    }
}
