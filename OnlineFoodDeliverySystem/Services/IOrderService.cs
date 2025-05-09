﻿using OnlineFoodDeliverySystem.Models;
namespace OnlineFoodDeliverySystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(int id, Order order);
        Task DeleteOrderAsync(int orderId);
    }
}
