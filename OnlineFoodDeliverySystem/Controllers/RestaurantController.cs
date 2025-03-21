using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Services;

namespace OnlineFoodDeliverySystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRestaurant([FromBody] Restaurant restaurant)
        {
            if (restaurant == null) {
                return BadRequest();
            }

            await _restaurantService.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.RestaurantID }, restaurant);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] Restaurant restaurant)
        {
           
            await _restaurantService.UpdateRestaurantAsync(id, restaurant);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }


    }
}
