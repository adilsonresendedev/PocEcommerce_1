using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.Shared.Filters;
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
        public async Task<IActionResult> Register([FromBody] UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseDTO<UserLoginViewModel> serviceResponseDTO = await _authService.Register(userToInsertViewModel);
            return Ok(serviceResponseDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] UserLoginViewModel userLoginViewModel)
        {
            ServiceResponseDTO<string> serviceResponseDTO = await _authService.Login(userLoginViewModel);
            return Ok(serviceResponseDTO);
        }
    }
}
