
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem;
using OnlineFoodDeliverySystem.Serivces;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("register")]
    public IActionResult AddCustomer([FromBody] Customer customer)
    {
        var result = _customerService.AddCustomer(customer);
        if (result > 0)
        {
            return Ok("Customer Registered Successfully");
        }
        return BadRequest("Registration Failed");
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customerService.GetCustomerById(id);
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
    {
        customer.CustomerID = id;
        var result = _customerService.UpdateCustomer(customer);
        if (result > 0)
        {
            return Ok("Customer Updated Successfully");
        }
        return NotFound("Customer Not Found");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var result = _customerService.DeleteCustomer(id);
        if (result > 0)
        {
            return Ok("Customer Deleted Successfully");
        }
        return NotFound("Customer Not Found");
    }
}
