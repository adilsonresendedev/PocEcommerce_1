using AutoMapper;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;

namespace PocEcommerce_1.Business
{
    public class ShoppingCartBusiness : IOrderBusiness
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ShoppingCartBusiness(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            Order order = await _orderRepository.GetById(id);
            if(order != null)
            {
                order.IsActive = false;
                await _orderRepository.Update(order);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<OrderDTO>> GetAll(OrderFilter orderFilter)
        {
            List<Order> order = await _orderRepository.GetAll(orderFilter);
            List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(order);
            return orderDTO;
        }

        public async Task<OrderDTO> GetById(int id)
        {
            Order order = await _orderRepository.GetById(id);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task<int> Insert(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            int IdInserted = await _orderRepository.Insert(order);
            return IdInserted;
        }
    }
}
