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
using Microsoft.Extensions.Configuration;

namespace GoodToyes.Controllers
{
    public class CartController : Controller
    {
        private readonly IProduct _product;
        private readonly ICart _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private readonly IOrder _order;
        private IConfiguration Configuration;

        public CartController(ICart context, IProduct product, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, IOrder order, IConfiguration configuration)
        {
            _context = context;
            _product = product;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _order = order;
            Configuration = configuration;
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

        public async Task<IActionResult> CheckOut()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            string userId = _userManager.GetUserId(User);

            Cart cart = await _context.GetCart(userId);


            cart.CartItems = await _context.GetCartItems(cart.ID);

            foreach (CartItem item in cart.CartItems)
            {
                cart.GrandTotal += item.Total;
                
            }
       
            return View(cart);
        }
        // <summary>
        // Checkout
        // </summary>
        // <returns>email</returns>
        public async Task<IActionResult> CheckoutReceipt()
        {
            decimal grandTotal = 0;

            ApplicationUser user = await _userManager.GetUserAsync(User);

            string userId = _userManager.GetUserId(User);

            Cart cart = await _context.GetCart(userId);


            cart.CartItems = await _context.GetCartItems(cart.ID);

            Order newOrder = await _order.CreateOrder(user, cart.GrandTotal);

            foreach (CartItem item in cart.CartItems)
            {
                await _order.CreateOrderItem(newOrder, item);
                
            }

            await _order.UpdateOrder(newOrder.ID, newOrder);

            newOrder.OrderItems = await _order.GetOrderItems(newOrder.ID);


            //email receipt
            ApplicationUser thisUser = await _userManager.FindByEmailAsync(user.Email);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1 align='center'>Order Confirmation</h1>");
            sb.AppendLine($"<h2>Good call {thisUser.FirstName}! We've got some Good Toyes on their way for your good boyes.</h2>");

            foreach (CartItem item in cart.CartItems)
            {
                grandTotal += item.Total;

                sb.AppendLine($"<h1>{item.Product.Name}</h1>");
                sb.AppendLine($"<h2>Qty: {item.Quantity}</h2>");
                sb.AppendLine($"<h2>Price: {item.Total}</h2>");
            }
            sb.AppendLine($"<h1>Grand Totoal: {grandTotal}</h1>");

            await _emailSender.SendEmailAsync(thisUser.Email, $"Order Confirmation", sb.ToString());

            //return to cart
            return View(cart);
        }

        public async Task<IActionResult> RunPayment(string cardNumber)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            string userId = _userManager.GetUserId(User);

            Cart cart = await _context.GetCart(userId);


            cart.CartItems = await _context.GetCartItems(cart.ID);
            //Run Payment
            Payment payment = new Payment(Configuration);

            payment.Run(cardNumber, user, cart);

            await CheckoutReceipt();

            return View("CheckoutReceipt");
        }

        /// <summary>
        /// Clears out user's cart after order
        /// </summary>
        /// <returns>Home index view</returns>
        public async Task<IActionResult> BackToShop()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            string userId = _userManager.GetUserId(User);

            Cart cart = await _context.GetCart(userId);

            cart.CartItems = await _context.GetCartItems(cart.ID);

            await _context.DeleteCartItems(cart.ID);

            return RedirectToAction("Index", "Home");
        }
    }
}
