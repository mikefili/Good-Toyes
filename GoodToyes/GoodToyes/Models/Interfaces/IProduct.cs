using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models.Interfaces
{
    interface IProduct
    {
        // CREATE PRODUCT
        Task CreateProduct(Product product);

        // GET PRODUCT
        Task<Product> GetProduct(int id);

        // GET PRODUCTS
        Task<IEnumerable<Product>> GetProducts();

        // UPDATE PRODUCT
        Task UpdateProduct(Product product);

        // DELETE PRODUCT
        Task DeleteProduct(int id);
    }
}
