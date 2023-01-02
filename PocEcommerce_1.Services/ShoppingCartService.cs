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
        private readonly IShoppingCartBusiness _shoppingCartBusiness;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingCartService(IShoppingCartBusiness shoppingCartBusiness, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _shoppingCartBusiness = shoppingCartBusiness;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<ShoppingCartViewModel>> Delete(int id)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ShoppingCartViewModel>();
            try
            {
                ShoppingCartDTO shoppingCartDTO = await _shoppingCartBusiness.GetById(id);
                if (shoppingCartDTO is null)
                {
                    serviceResponseViewModel.IsSucess = false;
                    serviceResponseViewModel.Message = ConstantMessages.RegisterNotFount;
                    return serviceResponseViewModel;
                }

                await _shoppingCartBusiness.Delete(id);
                await _unitOfWork.CommitAsync();
                shoppingCartDTO.IsActive = false;
                serviceResponseViewModel.Data = _mapper.Map<ShoppingCartViewModel>(shoppingCartDTO);
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

        public async Task<ServiceResponseViewModel<List<ShoppingCartViewModel>>> GetAll(ShoppingCartFilter shoppingCartFilter)
        {
            ServiceResponseViewModel<List<ShoppingCartViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<ShoppingCartViewModel>>();
            try
            {
                List<ShoppingCartDTO> shoppingCartDTO = await _shoppingCartBusiness.GetAll(shoppingCartFilter);
                List<ShoppingCartViewModel> shoppingCartViewModel = _mapper.Map<List<ShoppingCartViewModel>>(shoppingCartDTO);
                serviceResponseViewModel.Data = shoppingCartViewModel;
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

        public async Task<ServiceResponseViewModel<ShoppingCartViewModel>> GetById(int id)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ShoppingCartViewModel>();
            try
            {
                ShoppingCartDTO shoppingCartDTO = await _shoppingCartBusiness.GetById(id);
                ShoppingCartViewModel shoppingCartViewModel = _mapper.Map<ShoppingCartViewModel>(shoppingCartDTO);
                serviceResponseViewModel.Data = shoppingCartViewModel;
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

        public async Task<ServiceResponseViewModel<ShoppingCartViewModel>> Insert(ShoppingCartToInsertViewModel shoppingCartToInsertViewModel)
        {
            ServiceResponseViewModel<ShoppingCartViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ShoppingCartViewModel>();
            try
            {
                ShoppingCartDTO shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCartToInsertViewModel);
                shoppingCartDTO.Id = await _shoppingCartBusiness.Insert(shoppingCartDTO);
                await _unitOfWork.CommitAsync();
                ShoppingCartViewModel shoppingCartViewModel = _mapper.Map<ShoppingCartViewModel>(shoppingCartDTO);
                serviceResponseViewModel.Data = shoppingCartViewModel;
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