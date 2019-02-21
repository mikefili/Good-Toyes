using GoodToyes.Data;
using GoodToyes.Models.Interfaces;
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

        public Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
