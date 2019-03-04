using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GoodToyes.Models.Interfaces
{
    public interface ICart
    {
        //Create new cart item
        Task<HttpStatusCode> CreateCartItem(Cart cart, CartItem cartItem);

        //get cart item
        Task<CartItem> GetCartItem(int id);

        //Get all cart items
        Task<List<CartItem>> GetCartItems(int id);

        //delete cart item
        Task<HttpStatusCode> DeleteCartItem(int id);

        //update cart item
        Task<CartItem> UpdateCartItem(int id, CartItem cartItem);

        //Create cart
        Task<HttpStatusCode> CreateCart(ApplicationUser user);

        //get cart
        Task<Cart> GetCart(string id);

        //brings up update form
        Task<Cart> UpdateCartFirsStep(int id);
        
        //updates cart
        Task<Cart> UpdateCart(Cart cart);

        Task DeleteCartItems(int id);
    }
}
