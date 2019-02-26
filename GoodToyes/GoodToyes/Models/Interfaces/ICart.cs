using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models.Interfaces
{
    public interface ICart
    {
        // Saves to Cart
        Task SaveToCart(Product product);

        // Edit Purchas Details
        Task<Product> EditPurchas(int id);

        // Get all products in cart
        Task<IEnumerable<Product>> GetProducts();


        // Delete from item from cart
        Task DeleteProduct(int id);
    }
}
