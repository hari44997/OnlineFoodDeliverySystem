using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetDeliveryList();
        Delivery GetDeliveryById(int id);
        int UpdateStatus(int id, string  status);

        bool AddDelivery(Delivery delivery);
        void CancelDelivery(int deliveryId);

    }
}
