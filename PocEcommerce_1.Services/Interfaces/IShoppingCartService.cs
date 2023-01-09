using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ServiceResponseViewModel<OrderViewModel>> Insert(OrderToInsertViewModel orderToInsertViewModel);

        Task<ServiceResponseViewModel<OrderViewModel>> Delete(int id);

        Task<ServiceResponseViewModel<List<OrderViewModel>>> GetAll(OrderFilter orderFilter);

        Task<ServiceResponseViewModel<OrderViewModel>> GetById(int id);
    }
}
