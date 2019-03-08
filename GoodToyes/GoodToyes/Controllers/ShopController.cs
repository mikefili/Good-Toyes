using GoodToyes.Models;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduct _context;
        private readonly ICart _cart;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ShopController(IProduct context, ICart cart, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _cart = cart;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Returns the index view
        /// </summary>
        /// <returns>shop index view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Brings the details for a product to the shop details view
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Shop detail view</returns>
        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Adds a product to the user's cart
        /// </summary>
        /// <param name="cartItem">Product to be added to cart</param>
        /// <returns>Redirect to index</returns>
        public async Task<IActionResult> AddToCart(int id)
        {
            
            var user = _userManager.GetUserId(User);

            Product product = await _context.GetProduct(id);

            CartItem cartItem = new CartItem();

            cartItem.ProductID = id;

            cartItem.Product = product;

            cartItem.Total = cartItem.Product.Price * cartItem.Quantity;
            
            var cart = await _cart.GetCart(user);

            cart.GrandTotal = 0;

            var result = await _cart.CreateCartItem(cart, cartItem);

            foreach (CartItem item in cart.CartItems)
            {
                cart.GrandTotal += item.Total;

            }
            return Redirect(Url.RouteUrl(new { controller = "Shop", action = "Index" }) + "#productsline");
        }
    }
}
