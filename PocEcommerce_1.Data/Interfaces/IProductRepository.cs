using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Course> getById(int id);
        Task<List<Course>> GetAll(CourseFilter productFilter);
        Task<Course> Update(Course product);
        Task<Course> Insert(Course product);
    }
}
