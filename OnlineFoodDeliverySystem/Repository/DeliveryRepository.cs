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

        public async Task UpdateDeliveryAsync(int id,Delivery delivery)
        {
            var updatedelivery = await _context.Deliveries.FindAsync(id);
            updatedelivery.Status = delivery.Status;
            _context.Deliveries.Update(updatedelivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            var delivery = await _context.Deliveries.FindAsync(deliveryId);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
            }
        }
    }

}
