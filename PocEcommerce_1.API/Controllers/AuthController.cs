using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = await _authService.Register(userToInsertViewModel);
            return Ok(serviceResponseDTO);
        }

        [HttpGet]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login([FromQuery] UserViewModel userLoginViewModel)
        {
            ServiceResponseViewModel<string> serviceResponseDTO = await _authService.Login(userLoginViewModel);
            return Ok(serviceResponseDTO);
        }
    }
}
