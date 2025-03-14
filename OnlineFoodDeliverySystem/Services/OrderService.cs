
using Microsoft.AspNetCore.Components.Forms;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return orders.ToList();

        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException($"Order with id {orderId} does not exists");
            }
            return order;
        }

        public async Task AddOrderAsync(Order order)
        {
            var Addorder = await _orderRepository.GetOrderByIdAsync(order.OrderID);
            if (Addorder != null)
            {
                throw new AlreadyExistsException($"Order with {order.OrderID} already exists");
            }
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var Updateorder = await _orderRepository.GetOrderByIdAsync(id);
            if (Updateorder == null)
            {
                throw new NotFoundException($"Order with {order.OrderID} does not exists");
            }
            await _orderRepository.UpdateOrderAsync(id, order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var Deleteorder = await _orderRepository.GetOrderByIdAsync(orderId);
            if (Deleteorder == null)
            {
                throw new NotFoundException($"Order with id {orderId} does not exists");
            }
            await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}
