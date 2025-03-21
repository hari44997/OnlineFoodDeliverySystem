using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Services;


namespace OnlineFoodDeliverySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveriesController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var deliveries = await _deliveryService.GetAllDeliveriesAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryById(int id)
        {
            var delivery = await _deliveryService.GetDeliveryByIdAsync(id);
            //if (delivery == null)
            //{
            //    return NotFound();
            //}
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<IActionResult> AddDelivery([FromBody] Delivery delivery)
        {
            await _deliveryService.AddDeliveryAsync(delivery);
            return CreatedAtAction(nameof(GetDeliveryById), new { id = delivery.DeliveryID }, delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, [FromBody] Delivery delivery)
        {
            if (id != delivery.DeliveryID)
            {
                return BadRequest();
            }
            await _deliveryService.UpdateDeliveryAsync(id,delivery);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            await _deliveryService.DeleteDeliveryAsync(id);
            return NoContent();
        }
    }
}
