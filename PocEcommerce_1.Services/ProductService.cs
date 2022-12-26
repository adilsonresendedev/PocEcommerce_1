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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductBusiness _productBusiness;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IProductBusiness productBusiness, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productBusiness = productBusiness;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<ProductViewModel>> Delete(int id)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ProductViewModel>();
            try
            {
                ProductDTO productDTO = await _productBusiness.GetById(id);
                if (productDTO != null)
                {
                    await _productBusiness.Delete(id);
                }

                ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<List<ProductViewModel>>> GetAll(ProductFilter productFilter)
        {
            ServiceResponseViewModel<List<ProductViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<ProductViewModel>>();
            try
            {
                List<ProductDTO> productDTO = await _productBusiness.GetAll(productFilter);
                List<ProductViewModel> productViewModel = _mapper.Map<List<ProductViewModel>>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<ProductViewModel>> GetById(int id)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ProductViewModel>();
            try
            {
                ProductDTO productDTO = await _productBusiness.GetById(id);
                ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<ProductViewModel>> Insert(ProductToInsertViewModel productToInsertViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ProductViewModel>();
            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productToInsertViewModel);
                productDTO.Id = await _productBusiness.Insert(productDTO);
                ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<ProductViewModel>> Update(ProductViewModel productViewModel)
        {
            ServiceResponseViewModel<ProductViewModel> serviceResponseViewModel = new ServiceResponseViewModel<ProductViewModel>();
            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productViewModel);
                bool result = await _productBusiness.Update(productDTO);
                if (!result)
                {
                    serviceResponseViewModel.Message = ConstantMessages.RegisterNotFount;
                    return serviceResponseViewModel;
                }

                ProductViewModel productViewModelDatabase = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseViewModel.Data = productViewModelDatabase;
                await _unitOfWork.SaveChangesAsync();
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