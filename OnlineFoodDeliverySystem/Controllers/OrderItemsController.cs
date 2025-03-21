using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Services;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderitems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderitems);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var orderitem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderitem == null)
            {
                return NotFound();
            }
            return Ok(orderitem);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItem orderitem)
        {
            await _orderItemService.AddOrderItemAsync(orderitem);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderitem.OrderItemID }, orderitem);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateOrderItem(int id, [FromBody] OrderItem orderitem)
        {
            await _orderItemService.UpdateOrderItemAsync(id, orderitem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}
