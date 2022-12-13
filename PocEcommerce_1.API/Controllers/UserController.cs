using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UserLoginViewModel userViewModel)
        { 
            ServiceResponseDTO<UserLoginViewModel> serviceResponseDTO = new ServiceResponseDTO<UserLoginViewModel>();
            return Ok(serviceResponseDTO);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponseDTO<UserLoginViewModel> serviceResponseDTO = new ServiceResponseDTO<UserLoginViewModel>();
            return Ok(serviceResponseDTO);
        }
    }
}
