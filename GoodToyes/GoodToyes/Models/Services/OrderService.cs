using GoodToyes.Data;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models.Interfaces
{
    public class OrderService : IOrder
    {
        private GoodToyesDbContext _context;
        private SignInManager<ApplicationUser> _signInManager;

        public OrderService(SignInManager<ApplicationUser> signInManager, GoodToyesDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Creats a new instance of order
        /// </summary>
        /// <param name="user"></param>
        /// <param name="grandTotal"></param>
        /// <returns>The new order</returns>
        public async Task<Order> CreateOrder(ApplicationUser user, decimal grandTotal)
        {
            Order newOrder = new Order
            {
                UserID = user.Id,
                GrandTotal = grandTotal,
                OrderDate = DateTime.Today
            };

            //if (_signInManager.IsSignedIn(User))
            //{
            //    if (User.Claims.First(c => c.Type == "SpayNeuter").Value == "True")
            //    {
            //        grandTotal = grandTotal * Convert.ToDecimal(0.95);
            //    }
            //}
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }


        /// <summary>
        /// Creates a new OrderItem
        /// </summary>
        /// <param name="order"></param>
        /// <param name="cartItem"></param>
        /// <returns>the orderitem</returns>
        public async Task CreateOrderItem(Order order, CartItem cartItem)
        {
            OrderItem orderItem = new OrderItem
            {
                ProductID = cartItem.ProductID,
                OrderID = order.ID,
                Quantity = cartItem.Quantity
            };
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes order and cascade deletes orderitems
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOrder(int id)
        {
            var deleteOrder = await _context.Orders.FindAsync(id);
            var orderItems = _context.OrderItems.Where(i => i.OrderID == id).ToListAsync();
            _context.RemoveRange(orderItems);
            _context.Remove(deleteOrder);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes one order item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOrderItem(int id)
        {
            var deleteItem = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(deleteItem);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Get orderitems in order
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of order items</returns>
        public async Task<List<OrderItem>> GetOrderItems(int id)
        {
            var orderItems = await _context.OrderItems.Where(i => i.OrderID == id).ToListAsync();
            return orderItems;
        }

        /// <summary>
        /// Gets last 5 orders
        /// </summary>
        /// <returns>list of user's 5 most recent orders</returns>
        public async Task<List<Order>> GetFiveOrders(string userID)
        {
            var orders = await _context.Orders.Where(i => i.UserID == userID).OrderByDescending(o => o.ID).Take(5).ToListAsync();
            return orders;
        }

        /// <summary>
        /// Gets a specific order by ID
        /// </summary>
        /// <param name="id">ID of the order to be retrieved</param>
        /// <returns>Order requested by ID</returns>
        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        /// <summary>
        /// Updates an order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns>updated order</returns>
        public async Task<Order> UpdateOrder(int id, Order order)
        {
            var updateOrder = await _context.Orders.FindAsync(id);
            order.ID = updateOrder.ID;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Updates an order item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns>updated order item</returns>
        public async Task<OrderItem> UpdateOrderItem(int id, OrderItem product)
        {
            var updateItem = await _context.OrderItems.FindAsync(id);
            product.ID = updateItem.ID;
            _context.OrderItems.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await _context.Orders.OrderByDescending(o => o.ID).ToListAsync();
            return orders;
        }
    }
}
