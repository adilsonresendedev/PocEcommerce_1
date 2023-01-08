using PocEcommerce_1.DTOs;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<CourseDTO> GetById(int id);
        Task<List<CourseDTO>> GetAll(CourseFilter productFilter);
        Task<int> Insert(CourseDTO productDTO);
        Task<bool> Update(CourseDTO productDTO);
        Task<bool> Delete(int id);
    }
}
