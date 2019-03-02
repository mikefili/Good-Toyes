using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class CartController : Controller
    {
        private readonly IProduct _product;
        private readonly ICart _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;

        public CartController(ICart context, IProduct product, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _context = context;
            _product = product;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
    }
        /// <summary>
        /// Gets cart and cart items and displays to cart page
        /// </summary>
        /// <returns>CART</returns>
        public async Task<IActionResult> Index()
        {
            
            var userId = _userManager.GetUserId(User);

            var cart = await _context.GetCart(userId);

            cart.CartItems = await _context.GetCartItems(cart.ID);

            foreach(var item in cart.CartItems)
            {
                item.Product = await _product.GetProduct(item.ProductID);
            }

            return View(cart);
        }

        /// <summary>
        /// Deletes an Item from the cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _context.DeleteCartItem(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Update quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns>An view page</returns>
        public async Task<IActionResult> UpdateCartItem(int id, int quantity)
        {
            var cartItem = await _context.GetCartItem(id);

            cartItem.Quantity = quantity;

            var quan = cartItem.Quantity;

            cartItem.Total = cartItem.Product.Price * quan;

            var update = await _context.UpdateCartItem(id, cartItem);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Sends a email receipt
        /// </summary>
        /// <returns>email</returns>
        //public IActionResult CheckOut()
        //{
 

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<p>GOOD TOYES");
        //    sb.AppendLine("RECEIPT</p>");
        //    sb.AppendLine("RECEIPT</p>");

        //    // Get the user's email
        //    _emailSender.SendEmailAsync( sb.ToString());

        //    // How do i get a user's id?
        //    // Like this:
        //    var user = _userManager.FindByEmailAsync(lvm.Email);
        //    string id = user.i;
        //}


    }
}
