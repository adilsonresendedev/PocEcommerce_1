using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserToInsertViewModel userToInsertViewModel)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] UserLoginFilter userFilter)
        {
            return Ok();
        }
    }
}
