using AutoMapper;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductBusiness(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            Course product = await _productRepository.getById(id);
            CourseDTO productDTO = new CourseDTO();

            if (product != null)
            {
                product.IsActive = false;
                await _productRepository.Update(product);
            }

            return true;
        }

        public async Task<List<CourseDTO>> GetAll(CourseFilter productFilter)
        {
            List<Course> product = await _productRepository.GetAll(productFilter);
            List<CourseDTO> productDTO = _mapper.Map<List<CourseDTO>>(product);
            return productDTO;
        }

        public async Task<CourseDTO> GetById(int id)
        {
            Course product = await _productRepository.getById(id);
            CourseDTO productDTO = _mapper.Map<CourseDTO>(product);
            return productDTO;
        }

        public async Task<int> Insert(CourseDTO productDTO)
        {
            Course product = _mapper.Map<Course>(productDTO);
            await _productRepository.Insert(product);
            return product.Id;
        }

        public async Task<bool> Update(CourseDTO productDTO)
        {
            Course product = _mapper.Map<Course>(productDTO);
            await _productRepository.Update(product);
            return true;
        }
    }
}
