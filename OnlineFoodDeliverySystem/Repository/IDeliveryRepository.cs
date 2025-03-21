                                                                             using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetAllDeliveriesAsync();
        Task<Delivery> GetDeliveryByIdAsync(int deliveryId);
        Task AddDeliveryAsync(Delivery delivery);
        Task UpdateDeliveryAsync(int id, Delivery delivery);
        Task DeleteDeliveryAsync(int deliveryId);

    }
}
