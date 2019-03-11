using GoodToyes.Data;
using GoodToyes.Models;
using GoodToyes.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject2
{
    public class Product
    {
        [Fact]
        public void ProductGetWorks()
        {
            //arrange
            GoodToyes.Models.Product product = new GoodToyes.Models.Product();
            product.Name = "Toy";

            //Assert
            Assert.Equal("Toy", product.Name);
        }

        [Fact]
        public void ProductGetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Product product = new GoodToyes.Models.Product();
            product.Name = "Toy";
            product.Image = "img";


            //Assert
            Assert.Equal("img", product.Image);
        }

        [Fact]
        public void ProductSetWorks()
        {
            //arrange
            GoodToyes.Models.Product product = new GoodToyes.Models.Product();
            product.Name = "Toy";
            product.Image = "img";

            //act
            product.Image = "imgs";
            //Assert
            Assert.Equal("imgs", product.Image);
        }

        [Fact]
        public void ProductSetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Product product = new GoodToyes.Models.Product();
            product.Name = "Toy";
            product.Image = "img";

            //act
            product.Name = "Toys";
            //Assert
            Assert.Equal("Toys", product.Name);
        }

        [Fact]
        public async void CreateProductWorks()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("CreateProduct").Options;

            

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 1;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);
                var created = context.Products.FirstOrDefault(p => p.ID == product.ID);

                // Assert
                Assert.Equal(product, created);

            }
        }

        [Fact]
        public async void CreateProductWorksAgain()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("CreateProduct").Options;

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 2;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);
                var created = context.Products.FirstOrDefault(p => p.ID == product.ID);

                // Assert
                Assert.Equal(product, created);

            }
        }

        [Fact]
        public async void DeleteProductWorks()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("Deleteproduct").Options;

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 1;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);

                await service.DeleteProduct(1);
                var deleted = context.Products.FirstOrDefault(p => p.ID == product.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteProductWorksAgain()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("Deleteproduct").Options;

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 2;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);

                await service.DeleteProduct(2);
                var deleted = context.Products.FirstOrDefault(p => p.ID == product.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void UpdateProductWorks()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("UpdateProduct").Options;

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 2;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);

                product.Description = "bye";
                await service.UpdateProduct(product);
                // Assert
                Assert.Equal("bye", product.Description);

            }
        }

        [Fact]
        public async void UpdateProductWorksAgain()
        {
            DbContextOptions<GoodToyesDbContext> options =
                new DbContextOptionsBuilder<GoodToyesDbContext>
                ().UseInMemoryDatabase("UpdateProducts").Options;

            using (GoodToyesDbContext context = new GoodToyesDbContext(options))
            {
                // arrange
                GoodToyes.Models.Product product = new GoodToyes.Models.Product();
                product.Description = "hi";
                product.ID = 2;

                // Act
                ProductManager service = new ProductManager(context);

                await service.CreateProduct(product);

                product.Description = "Hello";
                await service.UpdateProduct(product);
                // Assert
                Assert.Equal("Hello", product.Description);

            }
        }
    }
}
