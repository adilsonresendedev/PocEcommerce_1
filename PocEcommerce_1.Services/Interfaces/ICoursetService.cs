using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface ICoursetService
    {
        Task<ServiceResponseViewModel<CourseViewModel>> Insert(CourseToInsertViewModel productToInsertViewModel);
        Task<ServiceResponseViewModel<CourseViewModel>> Update(CourseViewModel productViewModel);
        Task<ServiceResponseViewModel<CourseViewModel>> Delete(int id);
        Task<ServiceResponseViewModel<CourseViewModel>>GetById(int id);
        Task<ServiceResponseViewModel<List<CourseViewModel>>> GetAll(CourseFilter productFilter);
    }
}
