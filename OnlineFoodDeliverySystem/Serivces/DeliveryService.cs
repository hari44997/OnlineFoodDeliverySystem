using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class DeliveryService:IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            return await _deliveryRepository.GetAllDeliveriesAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            return await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            await _deliveryRepository.AddDeliveryAsync(delivery);
        }

        public async Task UpdateDeliveryAsync(Delivery delivery)
        {
            await _deliveryRepository.UpdateDeliveryAsync(delivery);
        }

        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            await _deliveryRepository.DeleteDeliveryAsync(deliveryId);
        }
    }
}
