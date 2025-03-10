
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDbContext _context;
        
        public OrderRepository(FoodDbContext context)
        {
            _context = context;
        }

        public bool AcceptedOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeliveredOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public bool PreparingOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool ProcessOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
