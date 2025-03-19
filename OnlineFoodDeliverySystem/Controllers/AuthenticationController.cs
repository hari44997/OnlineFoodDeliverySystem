using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;


namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication jwtAuth;

        public AuthenticationController(IAuthentication jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] User user)
        {
            var token = jwtAuth.Authenticate(user.EmailAddress, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}