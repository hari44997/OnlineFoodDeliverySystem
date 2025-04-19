using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<IEnumerable<OrderItem>> GetOrderItemsByCustomerIdAsync(int customerId);
        Task<OrderItem> GetOrderItemByCustomerAndItemAsync(int customerId, int itemId);

        Task AddOrderItemAsync(OrderItem orderItem);
        Task UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task DeleteOrderItemAsync(int id);
    }
}
