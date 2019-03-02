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
using GoodToyes.Models.ViewModels;
using GoodToyes.ViewModels;

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


        // <summary>
        // Sends a email receipt
        // </summary>
        // <returns>email</returns>
        public async Task<IActionResult> CheckOutEmail()
        {
            decimal grandTotal = 0;

            var user = await _userManager.GetUserAsync(User);

            var userId = _userManager.GetUserId(User);

            var cart = await _context.GetCart(userId);

            cart.CartItems = await _context.GetCartItems(cart.ID);

            var thisUser = await _userManager.FindByEmailAsync(user.Email);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<p>Thanks for shopping, come again</p>");

            foreach (var item in cart.CartItems)
            {
                grandTotal += item.Total;

                sb.AppendLine($"<h1>{item.Product.Name}</h1>");

                sb.AppendLine($"<h2>Qty: {item.Quantity}</h2>");

                sb.AppendLine($"<h2>Price: {item.Total}</h2>");

                
            }
            sb.AppendLine($"<p>Grand Totoal: {grandTotal}</p>");

            await _emailSender.SendEmailAsync(thisUser.Email, "Receipt", sb.ToString());

            return RedirectToAction("index");
        }


    }
}
