using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> getById(int id);
        Task<List<Product>> GetAll(ProductFilter productFilter);
        Task<Product> Update(Product product);
        Task<Product> Insert(Product product);
    }
}
