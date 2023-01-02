using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<bool> Update(ShoppingCart shoppingCart);
        Task<List<ShoppingCart>> GetAll(ShoppingCartFilter shoppingCartFilter);
        Task<ShoppingCart> GetById(int id);
        Task<int> Insert(ShoppingCart shoppingCart);
    }
}
