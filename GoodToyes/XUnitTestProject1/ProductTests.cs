using System;
using Xunit;
using GoodToyes.Models;

namespace XUnitTestProject1
{
    public class ProductTests
    {
        [Fact]
        public void ProductGetWorks()
        {
            //arrange
            Product product = new Product();
            product.Name = "Toy";

            //Assert
            Assert.Equal("Toy", product.Name);
        }

        [Fact]
        public void ProductGetWorksAgain()
        {
            //arrange
            Product product = new Product();
            product.Name = "Toy";
            product.ImageUrl = "img";


            //Assert
            Assert.Equal("img", product.ImageUrl);
        }

        [Fact]
        public void ProductSetWorks()
        {
            //arrange
            Product product = new Product();
            product.Name = "Toy";
            product.ImageUrl = "img";

            //act
            product.ImageUrl = "imgs";
            //Assert
            Assert.Equal("imgs", product.ImageUrl);
        }

        [Fact]
        public void ProductSetWorksAgain()
        {
            //arrange
            Product product = new Product();
            product.Name = "Toy";
            product.ImageUrl = "img";

            //act
            product.Name = "Toys";
            //Assert
            Assert.Equal("Toys", product.Name);
        }


    }
}
