using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly FoodDbContext _context;
        public OrderItemRepository(FoodDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var deleteOrderItem = await _context.OrderItems.FindAsync(id);
            if (deleteOrderItem != null)
            {
                _context.OrderItems.Remove(deleteOrderItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            var getorderItem = await _context.OrderItems.FindAsync(id);
            return getorderItem;
        }

        public async Task UpdateOrderItemAsync(int id, OrderItem orderItem)
        {
            var UpdateOrderItems = await _context.OrderItems.FindAsync(id);
            UpdateOrderItems.Quantity = orderItem.Quantity;
            UpdateOrderItems.Price = orderItem.Price;

            _context.OrderItems.Update(UpdateOrderItems);
            await _context.SaveChangesAsync();
        }
    }
}
