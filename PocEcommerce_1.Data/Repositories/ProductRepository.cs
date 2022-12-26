using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Data.Context;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetAll(ProductFilter productFilter)
        {
            IQueryable<Product> product = _appDbContext.Set<Product>()
                .Where(x => productFilter.Id != 0 ? x.Id == productFilter.Id : true)
                .Where(x => !string.IsNullOrWhiteSpace(productFilter.Description) ? x.Description.Contains(productFilter.Description) : true)
                .Skip(productFilter.Skip)
                .Take(productFilter.PageSize);

            List<Product> _product = await product
                .AsNoTracking()
                .ToListAsync();

            return _product;
        }

        public async Task<Product> getById(int id)
        {
            Product product = await _appDbContext.Set<Product>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> Insert(Product product)
        {
            await _appDbContext.Set<Product>().AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _appDbContext.Set<Product>().Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
    }
}
