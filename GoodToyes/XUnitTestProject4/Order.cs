using GoodToyes.Data;
using GoodToyes.Models;
using GoodToyes.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;


namespace XUnitTestProject4
{
    public class Order
    {
        [Fact]
        public void OrderGetWorks()
        {
            //arrange
            GoodToyes.Models.Order order = new GoodToyes.Models.Order();
            order.FirstName = "Jason";

            //Assert
            Assert.Equal("Jason", order.FirstName);
        }

        [Fact]
        public void OrderGetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Order order = new GoodToyes.Models.Order();
            order.FirstName = "Jason";
            order.LastName = "Few";
  
            //Assert
            Assert.Equal("Few", order.LastName);
        }

        [Fact]
        public void OrderSetWorks()
        {
            //arrange
            GoodToyes.Models.Order order = new GoodToyes.Models.Order();
            order.FirstName = "Jason";

            order.FirstName = "Jas";
            //Assert
            Assert.Equal("Jas", order.FirstName);
        }

        [Fact]
        public void OrderSetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Order order = new GoodToyes.Models.Order();
            order.FirstName = "Jason";
            order.LastName = "Few";


            order.LastName = "Fewer";
            //Assert
            Assert.Equal("Fewer", order.LastName);
        }

        [Fact]
        public void OrderItemGetWorks()
        {
            //arrange
            GoodToyes.Models.OrderItem orderItem = new GoodToyes.Models.OrderItem();
            orderItem.ID = 1;

            //Assert
            Assert.Equal(1, orderItem.ID);
        }

        [Fact]
        public void OrderItemGetWorksAgain()
        {
            //arrange
            GoodToyes.Models.OrderItem orderItem = new GoodToyes.Models.OrderItem();
            orderItem.ID = 1;
            orderItem.Quantity = 2;

            //Assert
            Assert.Equal(2, orderItem.Quantity);
        }

        [Fact]
        public void OrderItemSetWorks()
        {
            //arrange
            GoodToyes.Models.OrderItem orderItem = new GoodToyes.Models.OrderItem();
            orderItem.ID = 1;

            orderItem.ID = 2;
            //Assert
            Assert.Equal(2, orderItem.ID);
        }

        [Fact]
        public void OrderItemSetWorksAgain()
        {
            //arrange
            GoodToyes.Models.OrderItem orderItem = new GoodToyes.Models.OrderItem();
            orderItem.ID = 1;
            orderItem.Quantity = 2;

            orderItem.Quantity = 3;
            //Assert
            Assert.Equal(3, orderItem.Quantity);
        }
    }
}
