using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDbContext _context;

        public OrderRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var orderToUpdate = await _context.Orders.FindAsync(id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Status = order.Status;
                orderToUpdate.TotalAmount = order.TotalAmount;
                orderToUpdate.OrderDate = order.OrderDate;
                orderToUpdate.CustomerID = order.CustomerID;
                orderToUpdate.RestaurantID = order.RestaurantID;

                _context.Orders.Update(orderToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orderToDelete = await _context.Orders.FindAsync(orderId);
            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}