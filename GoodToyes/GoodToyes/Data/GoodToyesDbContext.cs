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

        public DbSet<Product> Products { get; set; }
    }
}
