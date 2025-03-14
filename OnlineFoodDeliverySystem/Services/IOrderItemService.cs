using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Services
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task AddOrderItemAsync(OrderItem orderitem);
        Task UpdateOrderItemAsync(int id, OrderItem orderitem);
        Task DeleteOrderItemAsync(int id);
    }
}
