using Microsoft.AspNetCore.Mvc;

namespace WebApiHandson8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Ok(new
            {
                Message = "Authentication Successful",
                Token = "sample-jwt-token"
            });
        }
    }
}