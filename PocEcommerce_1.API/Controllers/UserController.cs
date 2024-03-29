﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Update([FromBody] UserViewModel userViewModel)
        { 
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = new ServiceResponseViewModel<UserViewModel>();
            return Ok(serviceResponseDTO);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = new ServiceResponseViewModel<UserViewModel>();
            return Ok(serviceResponseDTO);
        }
    }
}
