using GoodToyes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class OrderService : IOrder
    {
        private GoodToyesDbContext _context;

        public OrderService(GoodToyesDbContext context)
        {
            _context = context;
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

            var orderItems = _context.OrderItems.Where(i => i.OrderID == id);

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



        public Task<List<OrderItem>> GetOrderItems(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task OrderComplete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> UpdateOrderItem(int id, OrderItem product)
        {
            throw new NotImplementedException();
        }
    }
}
