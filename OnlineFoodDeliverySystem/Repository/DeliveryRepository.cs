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

        public Delivery GetDeliveryById(int id)
        {
            return _context.Deliveries.Find(id);
        }

        public List<Delivery> GetDeliveryList()
        {
            return _context.Deliveries.ToList();
        }

        public int UpdateStatus(int id, string status)
        {
            var Updatestatus = _context.Deliveries.FirstOrDefault(d => d.DeliveryID == id);
            Updatestatus.Status = status;
            return _context.SaveChanges();
        }
        public bool AddDelivery(Delivery delivery)
        {
          var adddelivery= _context.Deliveries.FirstOrDefault(f => f.DeliveryID == delivery.DeliveryID);
            if (adddelivery == null)
            {
                _context.Deliveries.Add(delivery);
                return true;
            }
            return false;

        }
        public void CancelDelivery(int deliveryId)
        {
            var Canceldelivery = _context.Deliveries.FirstOrDefault(c => c.DeliveryID == deliveryId);
            _context.Deliveries.Remove(Canceldelivery);
            _context.SaveChanges();
        }
    }
}
