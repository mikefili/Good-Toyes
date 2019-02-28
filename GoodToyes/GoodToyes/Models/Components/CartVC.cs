using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodToyes.Models.Interfaces;
using GoodToyes.Data;
using Microsoft.EntityFrameworkCore;
using GoodToyes.ViewModels;

namespace GoodToyes.Models.Components
{
    public class CartVC : ViewComponent
    {
        private GoodToyesDbContext _context;
        private ICart _cart;
        private IProduct _product;

        public CartVC(GoodToyesDbContext context, ICart cart, IProduct product)
        {
            _context = context;
            _cart = cart;
            _product = product;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User.Identity.Name;
            var userCart = await _cart.GetCart(user);
            var userItems = userCart.CartItems.ToList();
            List<CartItemViewModel> cartItemVMList = new List<CartItemViewModel>();

            foreach (var item in userItems)
            {
                Product product = await _product.GetProduct(item.ProductID);
                CartItemViewModel cartItemVM = new CartItemViewModel();
                cartItemVM.ProductName = product.Name;
                cartItemVM.ProductPrice = product.Price;
                cartItemVM.Quantity = product.Quantity;
                cartItemVMList.Add(cartItemVM);
            }

            return View(cartItemVMList);
        }
    }
}
