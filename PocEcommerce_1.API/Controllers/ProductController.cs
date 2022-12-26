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
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] ProductToInsertViewModel productToInsertViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = await _productService.Insert(productToInsertViewModel);
            return Ok(serviceResponseViewModel);
        }


        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] ProductViewModel productViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = await _productService.Update(productViewModel);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilter productFilter)
        {
            ServiceResponseViewModel<List<ProductViewModel>> serviceResponseViewModel = await _productService.GetAll(productFilter);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetById) + "/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = await _productService.GetById(id);
            return Ok(serviceResponseViewModel);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = await _productService.Delete(id);
            return Ok(serviceResponseViewModel);
        }
    }
}
