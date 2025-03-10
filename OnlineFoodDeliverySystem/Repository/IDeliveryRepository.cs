using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetDeliveryList();
        Delivery GetDeliveryById(int id);
        Delivery GetAgentById(int id);

    }
}
