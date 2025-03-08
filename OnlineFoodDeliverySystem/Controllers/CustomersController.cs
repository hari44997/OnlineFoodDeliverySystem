using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public CustomersController(FoodDbContext context)
        {
            _context = context;
        }
        //Register
        [HttpPost]
        public void RegisterCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

    }
}
