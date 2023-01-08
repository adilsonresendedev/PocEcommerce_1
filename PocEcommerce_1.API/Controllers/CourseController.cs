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
    public class CourseController : ControllerBase
    {
        private ICoursetService _courseService;

        public CourseController(ICoursetService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route(nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody] CourseToInsertViewModel courseToInsertViewModel)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = await _courseService.Insert(courseToInsertViewModel);
            return Ok(serviceResponseViewModel);
        }


        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] CourseViewModel courseViewModel)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = await _courseService.Update(courseViewModel);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll([FromQuery] CourseFilter courseFilter)
        {
            ServiceResponseViewModel<List<CourseViewModel>> serviceResponseViewModel = await _courseService.GetAll(courseFilter);
            return Ok(serviceResponseViewModel);
        }

        [HttpGet]
        [Route(nameof(GetById) + "/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = await _courseService.GetById(id);
            return Ok(serviceResponseViewModel);
        }

        [HttpDelete]
        [Route(nameof(Delete) + "/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = await _courseService.Delete(id);
            return Ok(serviceResponseViewModel);
        }
    }
}
