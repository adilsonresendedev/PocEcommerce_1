using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<bool> Update(Order shoppingCart);
        Task<List<Order>> GetAll(ShoppingCartFilter shoppingCartFilter);
        Task<Order> GetById(int id);
        Task<int> Insert(Order shoppingCart);
    }
}
