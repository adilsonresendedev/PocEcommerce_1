using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] ProdutctToInsertViewModel produtctToInsertViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseDTO = new ServiceResponseViewModel<ProductViewModel>();
            return Ok(serviceResponseDTO);
        }


        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] ProductViewModel productViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseDTO = new ServiceResponseViewModel<ProductViewModel>();
            return Ok(serviceResponseDTO);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilter productFilter)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseDTO = new ServiceResponseViewModel<ProductViewModel>();
            return Ok(serviceResponseDTO);
        }

        [HttpGet]
        [Route(nameof(GetById) + "/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseDTO = new ServiceResponseViewModel<ProductViewModel>();
            return Ok(serviceResponseDTO);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete([FromQuery] ProductFilter productFilter)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseDTO = new ServiceResponseViewModel<ProductViewModel>();
            return Ok(serviceResponseDTO);
        }
    }
}
