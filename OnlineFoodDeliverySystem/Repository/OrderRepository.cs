
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

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public int UpdateOrderStatus(int id, string status)
        {
            var UpdateStatus = _context.Orders.FirstOrDefault(o => o.OrderID == id);
            UpdateStatus.Status = status;
            return _context.SaveChanges();
        }
    }
}
