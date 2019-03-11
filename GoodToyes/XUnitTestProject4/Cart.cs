using GoodToyes.Data;
using GoodToyes.Models;
using GoodToyes.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject2
{
    public class Cart
    {
        [Fact]
        public void CartGetWorks()
        {
            //arrange
            GoodToyes.Models.Cart cart = new GoodToyes.Models.Cart();
            cart.GrandTotal = 5;

            //Assert
            Assert.Equal(5, cart.GrandTotal);
        }

        [Fact]
        public void CartGetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Cart cart = new GoodToyes.Models.Cart();
            cart.GrandTotal = 5;
            cart.ID = 1;

            //Assert
            Assert.Equal(1, cart.ID);
        }

        [Fact]
        public void CartSetWorks()
        {
            //arrange
            GoodToyes.Models.Cart cart = new GoodToyes.Models.Cart();
            cart.GrandTotal = 5;

            cart.GrandTotal = 6;
            //Assert
            Assert.Equal(6, cart.GrandTotal);
        }

        [Fact]
        public void CartSetWorksAgain()
        {
            //arrange
            GoodToyes.Models.Cart cart = new GoodToyes.Models.Cart();
            cart.GrandTotal = 5;
            cart.ID = 1;

            cart.ID = 2;
            //Assert
            Assert.Equal(2, cart.ID);
        }

        [Fact]
        public void CartItemGetWorks()
        {
            //arrange
            GoodToyes.Models.CartItem cartItem = new GoodToyes.Models.CartItem();
            cartItem.CartID = 1;

            //Assert
            Assert.Equal(1, cartItem.CartID);
        }

        [Fact]
        public void CartItemGetWorksAgain()
        {
            //arrange
            GoodToyes.Models.CartItem cartItem = new GoodToyes.Models.CartItem();
            cartItem.CartID = 1;
            cartItem.ID = 2;

            //Assert
            Assert.Equal(2, cartItem.ID);
        }

        [Fact]
        public void CartItemSetWorks()
        {
            //arrange
            GoodToyes.Models.CartItem cartItem = new GoodToyes.Models.CartItem();
            cartItem.CartID = 1;

            cartItem.CartID = 2;
            //Assert
            Assert.Equal(2, cartItem.CartID);
        }

        [Fact]
        public void CartItemSetWorksAgain()
        {
            //arrange
            GoodToyes.Models.CartItem cartItem = new GoodToyes.Models.CartItem();
            cartItem.CartID = 1;
            cartItem.ID = 2;

            cartItem.ID = 3;
            //Assert
            Assert.Equal(3, cartItem.ID);
        }


    }
}
