using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Services;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserID }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("role/{role}")]
        public async Task<IActionResult> GetUserByRole(int role)
        {
            var user = await _userService.GetUsersByRoleAsync(role);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }

    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _userService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _userService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }

            await _userService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerID }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            await _userService.UpdateCustomerAsync(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _userService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }

    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AgentsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAgents()
        {
            var agents = await _userService.GetAllAgentsAsync();
            return Ok(agents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            var agent = await _userService.GetAgentByIdAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return Ok(agent);
        }

        [HttpPost]
        public async Task<IActionResult> AddAgent([FromBody] Agent agent)
        {
            if (agent == null)
            {
                return BadRequest("Agent data is required.");
            }

            await _userService.AddAgentAsync(agent);
            return CreatedAtAction(nameof(GetAgentById), new { id = agent.AgentID }, agent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgent(int id, [FromBody] Agent agent)
        {
            await _userService.UpdateAgentAsync(id, agent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _userService.DeleteAgentAsync(id);
            return NoContent();
        }
    }

    [Route("api/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminsController(IUserService userService)
        {
            _userService = userService;
        }


        //Admin Controller
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _userService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _userService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin data is required.");
            }

            await _userService.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = admin.AdminID }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
        {
            await _userService.UpdateAdminAsync(id, admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _userService.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}