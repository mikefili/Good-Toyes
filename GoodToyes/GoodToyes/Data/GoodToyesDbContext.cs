using GoodToyes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Data
{
    public class GoodToyesDbContext : DbContext
    {
        public GoodToyesDbContext(DbContextOptions<GoodToyesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 2,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 3,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 4,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 5,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 6,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 7,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 8,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 9,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                },
                new Product
                {
                    ID = 10,
                    Name = "",
                    SKU = "",
                    Price = 1m,
                    Description = "",
                    ImageURL = ""
                }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
