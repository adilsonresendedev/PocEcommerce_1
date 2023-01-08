using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ServiceResponseViewModel<ShoppingCartViewModel>> AddIten(ShoppingCartToInsertViewModel shoppingCartToInsertViewModel);

        Task<ServiceResponseViewModel<ShoppingCartViewModel>> RemoveIten(ShoppingCartFilter shoppingCartFilter);

        Task<ServiceResponseViewModel<List<ShoppingCartViewModel>>> GetAll(ShoppingCartFilter shoppingCartFilter);

        Task<ServiceResponseViewModel<ShoppingCartViewModel>> GetById(int id);
    }
}
