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
            Product product = await _productRepository.getById(id);
            ProductDTO productDTO = new ProductDTO();

            if (product != null)
            {
                product.IsActive = false;
                await _productRepository.Update(product);
            }

            return true;
        }

        public async Task<List<ProductDTO>> GetAll(ProductFilter productFilter)
        {
            List<Product> product = await _productRepository.GetAll(productFilter);
            List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(product);
            return productDTO;
        }

        public async Task<ProductDTO> GetById(int id)
        {
            Product product = await _productRepository.getById(id);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task<int> Insert(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            await _productRepository.Insert(product);
            return product.Id;
        }

        public async Task<bool> Update(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            await _productRepository.Update(product);
            return true;
        }
    }
}
