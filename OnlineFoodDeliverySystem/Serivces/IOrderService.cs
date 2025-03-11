namespace OnlineFoodDeliverySystem.Serivces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        int UpdateOrderStatus(int id, string status);
        int DeleteOrder(int id);
    }
}
