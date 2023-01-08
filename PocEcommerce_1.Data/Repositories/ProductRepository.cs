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

        public async Task<List<Course>> GetAll(CourseFilter productFilter)
        {
            IQueryable<Course> product = _appDbContext.Set<Course>()
                .Where(x => productFilter.Id != 0 ? x.Id == productFilter.Id : true)
                .Where(x => !string.IsNullOrWhiteSpace(productFilter.Description) ? x.Description.Contains(productFilter.Description) : true)
                .Skip(productFilter.Skip)
                .Take(productFilter.PageSize);

            List<Course> _product = await product
                .AsNoTracking()
                .ToListAsync();

            return _product;
        }

        public async Task<Course> getById(int id)
        {
            Course product = await _appDbContext.Set<Course>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Course> Insert(Course product)
        {
            await _appDbContext.Set<Course>().AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Course> Update(Course product)
        {
            _appDbContext.Set<Course>().Update(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
    }
}
