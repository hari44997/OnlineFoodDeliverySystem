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

        public Delivery GetAgentById(int id)
        {
            return _context.Deliveries.FirstOrDefault(p => p.AgentID == id);
        }
    }
}
