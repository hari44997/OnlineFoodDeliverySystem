using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task AddOrderItemAsync(OrderItem orderitem)
        {
            await _orderItemRepository.AddOrderItemAsync(orderitem);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var Deleteorderitem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            if (Deleteorderitem == null)
            {
                throw new NotFoundException($"Order with id {id} does not exists");
            }
            await _orderItemRepository.DeleteOrderItemAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            var orderitems = await _orderItemRepository.GetAllOrderItemsAsync();
            return orderitems.ToList();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            var orderitem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            if (orderitem == null)
            {
                throw new NotFoundException($"Order with id {id} does not exists");
            }
            return orderitem;
        }

        public async Task UpdateOrderItemAsync(int id, OrderItem orderitem)
        {
            var Updateorderitem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            if (Updateorderitem == null)
            {
                throw new NotFoundException($"Order with id {id} does not exists");
            }
            await _orderItemRepository.UpdateOrderItemAsync(id, orderitem);
        }
    }
}
