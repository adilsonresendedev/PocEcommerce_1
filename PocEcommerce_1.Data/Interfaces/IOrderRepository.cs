using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> Update(Order shoppingCart);
        Task<List<Order>> GetAll(OrderFilter shoppingCartFilter);
        Task<Order> GetById(int id);
        Task<int> Insert(Order shoppingCart);
    }
}
