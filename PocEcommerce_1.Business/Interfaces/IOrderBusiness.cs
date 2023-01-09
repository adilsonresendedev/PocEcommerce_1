using PocEcommerce_1.DTOs;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business.Interfaces
{
    public  interface IOrderBusiness
    {
        Task<int> Insert(OrderDTO shoppingCartDTO);
        Task<bool> Delete(int id);
        Task<OrderDTO> GetById(int id);
        Task<List<OrderDTO>> GetAll(OrderFilter shoppingCartFilter);
    }
}
