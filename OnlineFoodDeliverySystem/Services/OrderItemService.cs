using Microsoft.EntityFrameworkCore;
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
            // 1. Check if an item with the same CustomerID and ItemID already exists
            var existingOrderItem = await _orderItemRepository.GetOrderItemByCustomerAndItemAsync(orderitem.CustomerID, orderitem.ItemID.Value);

            if (existingOrderItem != null)
            {
                // 2. If it exists, update the quantity
                existingOrderItem.Quantity += orderitem.Quantity; // Add the new quantity to the existing
                await _orderItemRepository.UpdateOrderItemAsync(existingOrderItem.OrderItemID, existingOrderItem);
            }
            else
            {
                await _orderItemRepository.AddOrderItemAsync(orderitem);
            }
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


        public async Task<IEnumerable<OrderItem>> GetOrderItemsByCustomerIdAsync(int customerId)
        {
            return await _orderItemRepository.GetOrderItemsByCustomerIdAsync(customerId);
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
