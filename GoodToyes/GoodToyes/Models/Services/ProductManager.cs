using GoodToyes.Data;
using GoodToyes.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models.Services
{
    public class ProductManager : IProduct
    {
        private readonly GoodToyesDbContext _context;

        public ProductManager(GoodToyesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">product to be created</param>
        /// <returns>Save task</returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a specific product by ID
        /// </summary>
        /// <param name="id">ID of product to delete</param>
        /// <returns>Save task</returns>
        public async Task DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific product from the Db by ID
        /// </summary>
        /// <param name="id">ID of product to get</param>
        /// <returns>Desired product</returns>
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
        }
        
        /// <summary>
        /// Gets a list of products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns>Updated product</returns>
        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
