using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetDeliveryList();
        Delivery GetDeliveryById(int id);
        int UpdateStatus(int id, string  status);

        void AddDelivery(Delivery delivery);
        void CancelDelivery(int deliveryId);

    }
}
