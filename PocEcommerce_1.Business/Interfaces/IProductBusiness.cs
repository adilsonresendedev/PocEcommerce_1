using PocEcommerce_1.DTOs;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<ProductDTO> GetById(int id);
        Task<List<ProductDTO>> GetAll(ProductFilter productFilter);
        Task<int> Insert(ProductDTO productDTO);
        Task<bool> Update(ProductDTO productDTO);
        Task<bool> Delete(int id);
    }
}
