﻿using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Services
{
    public interface IDeliveryService
    {
        Task<IEnumerable<Delivery>> GetAllDeliveriesAsync();
        Task<Delivery> GetDeliveryByIdAsync(int deliveryId);
        Task AddDeliveryAsync(Delivery delivery);
        Task UpdateDeliveryAsync(int id, Delivery delivery);
        Task DeleteDeliveryAsync(int deliveryId);
    }
}
