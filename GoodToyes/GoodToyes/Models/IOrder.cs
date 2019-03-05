using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    interface IOrder
    {
        //Creates a new order
        Task<Order> CreateOrder(ApplicationUser user, decimal grandTotal);

        //Creates an order item
        Task CreateOrderItem(Order order, CartItem cartItem);

        //Completes the order
        Task OrderComplete(int id);

        //deletes an order
        Task DeleteOrder(int id);

        //deletes and orser item
        Task DeleteOrderItem(int id);

        //get a list of orders
        Task<List<Order>> GetOrders();

        //gets a list of order items
        Task<List<OrderItem>> GetOrderItems(int id);

        //updates an order
        Task<Order> UpdateOrder(int id, Order order);

        //updates an order item
        Task<OrderItem> UpdateOrderItem(int id, OrderItem product);
    }
}
