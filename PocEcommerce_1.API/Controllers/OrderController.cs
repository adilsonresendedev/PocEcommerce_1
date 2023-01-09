using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IShoppingCartService _shoppingCartService;

        public OrderController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        [Route(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] OrderToInsertViewModel OrderToInsertViewModel)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = await _shoppingCartService.Insert(OrderToInsertViewModel);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] OrderFilter OrderFilter)
        {
            ServiceResponseViewModel<List<OrderViewModel>> serviceResponseViewModel = await _shoppingCartService.GetAll(OrderFilter);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetById) + "/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = await _shoppingCartService.GetById(id);
            return Ok(serviceResponseViewModel);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = await _shoppingCartService.Delete(id);
            return Ok(serviceResponseViewModel);
        }

    }
}
