namespace OnlineFoodDeliverySystem.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        int AddOrder(Order order);
        bool ProcessOrder(Order order);
        bool AcceptedOrder(Order order);
        bool PreparingOrder(Order order);
        bool DeliveredOrder(Order order);

    }
}
