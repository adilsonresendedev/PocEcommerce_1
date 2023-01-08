using AutoMapper;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business
{
    public class ShoppingCartBusiness : IShoppingCartBusiness
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public ShoppingCartBusiness(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<bool> RemoveIten(int id)
        {
            return await _shoppingCartRepository.Delete(id);
        }

        public async Task<List<ShoppingCartDTO>> GetAll(ShoppingCartFilter shoppingCartFilter)
        {
            List<Order> shoppingCart = await _shoppingCartRepository.GetAll(shoppingCartFilter);
            List<ShoppingCartDTO> shoppingCartDTO = _mapper.Map<List<ShoppingCartDTO>>(shoppingCart);
            return shoppingCartDTO;
        }

        public async Task<ShoppingCartDTO> GetById(int id)
        {
            Order shoppingCart = await _shoppingCartRepository.GetById(id);
            ShoppingCartDTO shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCart);
            return shoppingCartDTO;
        }

        public async Task<int> Insert(ShoppingCartDTO shoppingCartDTO)
        {
            Order shoppingCart = _mapper.Map<Order>(shoppingCartDTO);
            int IdInserted = await _shoppingCartRepository.Insert(shoppingCart);
            return IdInserted;
        }
    }
}
