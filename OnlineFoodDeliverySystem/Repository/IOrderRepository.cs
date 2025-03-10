namespace OnlineFoodDeliverySystem.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        int UpdateOrderStatus(int id, string status);

    }
}
