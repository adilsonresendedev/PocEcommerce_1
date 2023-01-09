using AutoMapper;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.UnitOfWork;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.Shared.Filters;
using PocEcommerce_1.Shared.Messages;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingCartService(IOrderBusiness OrderBusiness, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderBusiness = OrderBusiness;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<OrderViewModel>> Delete(int  id)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = new ServiceResponseViewModel<OrderViewModel>();
            try
            {
                OrderDTO orderDTO = await _orderBusiness.GetById(id);
                if (orderDTO is null)
                {
                    serviceResponseViewModel.IsSucess = false;
                    serviceResponseViewModel.Message = ConstantMessages.RegisterNotFount;
                    return serviceResponseViewModel;
                }

                await _orderBusiness.Delete(id);
                await _unitOfWork.CommitAsync();
                orderDTO.IsActive = false;
                serviceResponseViewModel.Data = _mapper.Map<OrderViewModel>(orderDTO);
                return serviceResponseViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<List<OrderViewModel>>> GetAll(OrderFilter orderFilter)
        {
            ServiceResponseViewModel<List<OrderViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<OrderViewModel>>();
            try
            {
                List<OrderDTO> orderDTO = await _orderBusiness.GetAll(orderFilter);
                List<OrderViewModel> OrderViewModel = _mapper.Map<List<OrderViewModel>>(orderDTO);
                serviceResponseViewModel.Data = OrderViewModel;
                return serviceResponseViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<OrderViewModel>> GetById(int id)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = new ServiceResponseViewModel<OrderViewModel>();
            try
            {
                OrderDTO OrderDTO = await _orderBusiness.GetById(id);
                OrderViewModel OrderViewModel = _mapper.Map<OrderViewModel>(OrderDTO);
                serviceResponseViewModel.Data = OrderViewModel;
                return serviceResponseViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<OrderViewModel>> Insert(OrderToInsertViewModel OrderToInsertViewModel)
        {
            ServiceResponseViewModel<OrderViewModel> serviceResponseViewModel = new ServiceResponseViewModel<OrderViewModel>();
            try
            {
                OrderDTO OrderDTO = _mapper.Map<OrderDTO>(OrderToInsertViewModel);
                OrderDTO.Id = await _orderBusiness.Insert(OrderDTO);
                await _unitOfWork.CommitAsync();
                OrderViewModel orderViewModel = _mapper.Map<OrderViewModel>(OrderDTO);
                serviceResponseViewModel.Data = orderViewModel;
                return serviceResponseViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }
    }
}