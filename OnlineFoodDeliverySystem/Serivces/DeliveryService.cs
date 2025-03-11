using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class DeliveryService:IDeliverService
    {
        private readonly FoodDbContext _context;

        public DeliveryService(FoodDbContext context)
        {
            _context = context;
        }

        public void AddDelivery(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public void CancelDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public Delivery GetDeliveryById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetDeliveryList()
        {
            throw new NotImplementedException();
        }

        public int UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
