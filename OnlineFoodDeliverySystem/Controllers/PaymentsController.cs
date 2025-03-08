using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public PaymentsController(FoodDbContext context)
        {
            _context = context;
        }
    }
}
