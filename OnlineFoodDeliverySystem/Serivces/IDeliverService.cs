using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Serivces
{
    public interface IDeliverService
    {
        List<Delivery> GetDeliveryList();
        Delivery GetDeliveryById(int id);
        int UpdateStatus(int id, string status);

        void AddDelivery(Delivery delivery);
        void CancelDelivery(int deliveryId);
    }
}
