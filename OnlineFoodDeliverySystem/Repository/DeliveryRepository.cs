using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly FoodDbContext _context;

        public DeliveryRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            return await _context.Deliveries.FindAsync(deliveryId);
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeliveryAsync(int id, Delivery delivery)
        {
            var deliveryToUpdate = await _context.Deliveries.FindAsync(id);
            if (deliveryToUpdate != null)
            {
                deliveryToUpdate.Status = delivery.Status;
                deliveryToUpdate.EstimatedTimeOfArrival = delivery.EstimatedTimeOfArrival;
                deliveryToUpdate.OrderID = delivery.OrderID;
                deliveryToUpdate.AgentID = delivery.AgentID;
                _context.Deliveries.Update(deliveryToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            var deliveryToDelete = await _context.Deliveries.FindAsync(deliveryId);
            if (deliveryToDelete != null)
            {
                _context.Deliveries.Remove(deliveryToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}