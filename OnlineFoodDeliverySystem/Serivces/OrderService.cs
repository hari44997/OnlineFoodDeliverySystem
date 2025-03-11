
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class OrderService : IOrderService
    {
        private readonly FoodDbContext _context;

        public OrderService(FoodDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrderStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
