using Microsoft.AspNetCore.Http.HttpResults;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
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

            var delivery =  await _deliveryRepository.GetAllDeliveriesAsync();
            return delivery.ToList();
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            Delivery delivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if (delivery == null)
            {
                throw new NotFoundException($"Delivery with id {deliveryId} does not exists");
            }
            return delivery;
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            var AddDelivery =  _deliveryRepository.GetDeliveryByIdAsync(delivery.DeliveryID);
            if (AddDelivery != null)
            {
                throw new AlreadyExistsException($"Delivery with id {delivery.DeliveryID} already exists");
            }    
            await _deliveryRepository.AddDeliveryAsync(delivery);
        }

        public async Task UpdateDeliveryAsync(int id,Delivery delivery)
        {
            var Updatedelivery = await _deliveryRepository.GetDeliveryByIdAsync(id);
            if (Updatedelivery == null)
            {
                throw new NotFoundException($"Delivery with id {id} does not exists");
            }
            await _deliveryRepository.UpdateDeliveryAsync(id,delivery);
        }

        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            var deletedelivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if (deletedelivery == null)
            {
                throw new NotFoundException($"Delivery with id {deliveryId} already exists");
            }
            await _deliveryRepository.DeleteDeliveryAsync(deliveryId);
        }
    }
}
