﻿using Microsoft.EntityFrameworkCore;
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
            var orderItemToDelete = await _context.OrderItems.FindAsync(id);
            if (orderItemToDelete != null)
            {
                _context.OrderItems.Remove(orderItemToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task UpdateOrderItemAsync(int id, OrderItem orderItem)
        {
            var orderItemToUpdate = await _context.OrderItems.FindAsync(id);
            if (orderItemToUpdate != null)
            {
                orderItemToUpdate.Quantity = orderItem.Quantity;
                orderItemToUpdate.Price = orderItem.Price;
                orderItemToUpdate.OrderID = orderItem.OrderID;
                orderItemToUpdate.ItemID = orderItem.ItemID;

                _context.OrderItems.Update(orderItemToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}