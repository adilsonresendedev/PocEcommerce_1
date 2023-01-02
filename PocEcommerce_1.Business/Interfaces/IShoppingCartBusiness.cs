using PocEcommerce_1.DTOs;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business.Interfaces
{
    public  interface IShoppingCartBusiness
    {
        Task<int> Insert(ShoppingCartDTO shoppingCartDTO);
        Task<bool> Delete(int id);
        Task<ShoppingCartDTO> GetById(int id);
        Task<List<ShoppingCartDTO>> GetAll(ShoppingCartFilter shoppingCartFilter);
    }
}
