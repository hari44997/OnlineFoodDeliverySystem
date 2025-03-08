using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly FoodDbContext _context;

        private static List<Order> orders = new List<Order>();
        public OrdersController(FoodDbContext context)
        {
            this._context = context;
        }
        //Placing Order
        [HttpPost]
        public void PlaceOrder([FromBody] Order order)
        {
            order.OrderID = orders.Count + 1;
            order.Status = "Pending";
            orders.Add(order);
            _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderStatus(int id)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.Status);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] string status)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = status;
            return Ok(order);
        }



    }
}
