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
            product.Image = "img";


            //Assert
            Assert.Equal("img", product.Image);
        }

        [Fact]
        public void ProductSetWorks()
        {
            //arrange
            Product product = new Product();
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
            Product product = new Product();
            product.Name = "Toy";
            product.Image = "img";

            //act
            product.Name = "Toys";
            //Assert
            Assert.Equal("Toys", product.Name);
        }


    }
}
