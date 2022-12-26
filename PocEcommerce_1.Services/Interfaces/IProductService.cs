using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponseViewModel<ProductViewModel>> Insert(ProductToInsertViewModel productToInsertViewModel);
        Task<ServiceResponseViewModel<ProductViewModel>> Update(ProductViewModel productViewModel);
        Task<ServiceResponseViewModel<ProductViewModel>> Delete(int id);
        Task<ServiceResponseViewModel<ProductViewModel>>GetById(int id);
        Task<ServiceResponseViewModel<List<ProductViewModel>>> GetAll(ProductFilter productFilter);
    }
}
