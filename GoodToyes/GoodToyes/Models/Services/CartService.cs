using GoodToyes.Data;
using GoodToyes.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GoodToyes.Models.Services
{
    public class CartService : ICart
    {
        private GoodToyesDbContext _context;
        /// <summary>
        /// Brings in DB
        /// </summary>
        /// <param name="context"></param>
        public CartService(GoodToyesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new instance of cart
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CreateCart(ApplicationUser user)
        {
            Cart cart = new Cart
            {
                UserID = user.Id
            };

            await _context.Carts.AddAsync(cart);

            await _context.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Creates new cart item
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CreateCartItem(Cart cart, CartItem cartItem)
        {
            cartItem.CartID = cart.ID;

            await _context.CartItems.AddAsync(cartItem);

            await _context.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        /// <summary>
        /// Deletes a cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DeleteCart(int id)
        {
            var deleted = await _context.Carts.FindAsync(id);
          
            var cartItemsCascade = await _context.CartItems.Where(i => i.CartID == id).ToListAsync();

            _context.CartItems.RemoveRange(cartItemsCascade);

            _context.Carts.Remove(deleted);

            await _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Deletes a cart item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DeleteCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            _context.CartItems.Remove(cartItem);

            await _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Gets all the carts 
        /// </summary>
        /// <returns>List of carts</returns>
        public async Task<List<Cart>> GetCarts()
        {
            var allCarts = await _context.Carts.ToListAsync();

            return allCarts;
        }

        /// <summary>
        /// Gets one cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cart> GetCart(string id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(i => i.UserID == id);

            return cart;
        }

        /// <summary>
        /// Gets one cart item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CartItem> GetCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            return cartItem;
        }

        /// <summary>
        /// Gets all the cart items
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of cart items</returns>
        public async Task<List<CartItem>> GetCartItems(int id)
        {
            var AllCartItems = await _context.CartItems.Where(i => i.CartID == id).ToListAsync();

            return AllCartItems;
        }

        /// <summary>
        /// Brings up form to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cart> UpdateCartFirsStep(int id)
        {
            return await _context.Carts.FindAsync(id);
        }


        /// <summary>
        /// Updates cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);

            await _context.SaveChangesAsync();

            return cart;
        }

        /// <summary>
        /// updates cart item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public async Task<CartItem> UpdateCartItem(int id, CartItem cartItem)
        {
            cartItem.ID = id;

            _context.CartItems.Update(cartItem);

            await _context.SaveChangesAsync();

            return cartItem;
        }
    }
}
