using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        [Route(nameof(AddIten))]
        public async Task<IActionResult> AddIten([FromBody] ShoppingCartToInsertViewModel shoppingCartToInsertViewModel)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = await _shoppingCartService.AddIten(shoppingCartToInsertViewModel);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] ShoppingCartFilter shoppingCartFilter)
        {
            ServiceResponseViewModel<List<ShoppingCartViewModel>> serviceResponseViewModel = await _shoppingCartService.GetAll(shoppingCartFilter);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetById) + "/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = await _shoppingCartService.GetById(id);
            return Ok(serviceResponseViewModel);
        }

        [HttpDelete]
        [Route(nameof(RemoveIten) + "/{id:int}")]
        public async Task<IActionResult> RemoveIten(ShoppingCartFilter shoppingCartFilter)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = await _shoppingCartService.RemoveIten(shoppingCartFilter);
            return Ok(serviceResponseViewModel);
        }

    }
}
