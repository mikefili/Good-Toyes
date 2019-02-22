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
                    Name = "Avacado's Nibbler",
                    SKU = "DT00001",
                    Price = 12.95m,
                    Description = "Your puppers will love this tasty toy from south of the border!",
                    Image = "Assets/Products/avacado_toy.png"
                },
                new Product
                {
                    ID = 2,
                    Name = "Throw Me A Bone",
                    SKU = "DT00002",
                    Price = 8.95m,
                    Description = "You can't got wrong with this time-tested classic.",
                    Image = "Assets/Products/bone_toy.png"
                },
                new Product
                {
                    ID = 3,
                    Name = "Cluckin' Good Time",
                    SKU = "DT00003",
                    Price = 12.95m,
                    Description = "A fine, feathered friend for your four-legged friend!",
                    Image = "Assets/Products/chicken_toy.png"
                },
                new Product
                {
                    ID = 4,
                    Name = "Donut Bother Me",
                    SKU = "DT00004",
                    Price = 12.95m,
                    Description = "Perfect side toy for your doggo's morning puppaccino!",
                    Image = "Assets/Products/donut_toy.png"
                },
                new Product
                {
                    ID = 5,
                    Name = "Ain't No Thing Like A Chicken Wing",
                    SKU = "DT00005",
                    Price = 12.95m,
                    Description = "Barbeque sauce sold separately.",
                    Image = "Assets/Products/drumstick_toy.png"
                },
                new Product
                {
                    ID = 6,
                    Name = "I Mustache You A Question",
                    SKU = "DT00006",
                    Price = 13.95m,
                    Description = "WARNING: May turn your pooch into an old timey movie villain.",
                    Image = "Assets/Products/mustache_toy.png"
                },
                new Product
                {
                    ID = 7,
                    Name = "Pizza My Heart",
                    SKU = "DT00007",
                    Price = 12.95m,
                    Description = "That classic thin-crust your dog loves, now in plush!",
                    Image = "Assets/Products/pizza_toy.png"
                },
                new Product
                {
                    ID = 8,
                    Name = "Pug'o'War",
                    SKU = "DT00008",
                    Price = 7.95m,
                    Description = "To the victor, go the spoils!",
                    Image = "Assets/Products/rope_toy.png"
                },
                new Product
                {
                    ID = 9,
                    Name = "Doggy Dentures",
                    SKU = "DT00009",
                    Price = 13.95m,
                    Description = "Give your woofer the beautiful pearly whites they deserve.",
                    Image = "Assets/Products/smile_toy.png"
                },
                new Product
                {
                    ID = 10,
                    Name = "Jingle Balls",
                    SKU = "DT00010",
                    Price = 8.95m,
                    Description = "Set of three extra jingly tennis balls.",
                    Image = "Assets/Products/tennis_balls.png"
                }
                );
        }
        public DbSet<Product> Products { get; set; }
    }
}
