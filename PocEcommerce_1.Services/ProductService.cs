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
    public class ProductService : ICoursetService
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

        public async Task<ServiceResponseViewModel<CourseViewModel>> Delete(int id)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = new ServiceResponseViewModel<CourseViewModel>();
            try
            {
                CourseDTO productDTO = await _productBusiness.GetById(id);
                if (productDTO != null)
                {
                    await _productBusiness.Delete(id);
                }

                CourseViewModel productViewModel = _mapper.Map<CourseViewModel>(productDTO);
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

        public async Task<ServiceResponseViewModel<List<CourseViewModel>>> GetAll(CourseFilter productFilter)
        {
            ServiceResponseViewModel<List<CourseViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<CourseViewModel>>();
            try
            {
                List<CourseDTO> productDTO = await _productBusiness.GetAll(productFilter);
                List<CourseViewModel> productViewModel = _mapper.Map<List<CourseViewModel>>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<CourseViewModel>> GetById(int id)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = new ServiceResponseViewModel<CourseViewModel>();
            try
            {
                CourseDTO productDTO = await _productBusiness.GetById(id);
                CourseViewModel productViewModel = _mapper.Map<CourseViewModel>(productDTO);
                serviceResponseViewModel.Data = productViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<CourseViewModel>> Insert(CourseToInsertViewModel productToInsertViewModel)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = new ServiceResponseViewModel<CourseViewModel>();
            try
            {
                CourseDTO productDTO = _mapper.Map<CourseDTO>(productToInsertViewModel);
                productDTO.Id = await _productBusiness.Insert(productDTO);
                CourseViewModel productViewModel = _mapper.Map<CourseViewModel>(productDTO);
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

        public async Task<ServiceResponseViewModel<CourseViewModel>> Update(CourseViewModel productViewModel)
        {
            ServiceResponseViewModel<CourseViewModel> serviceResponseViewModel = new ServiceResponseViewModel<CourseViewModel>();
            try
            {
                CourseDTO productDTO = _mapper.Map<CourseDTO>(productViewModel);
                bool result = await _productBusiness.Update(productDTO);
                if (!result)
                {
                    serviceResponseViewModel.Message = ConstantMessages.RegisterNotFount;
                    return serviceResponseViewModel;
                }

                CourseViewModel productViewModelDatabase = _mapper.Map<CourseViewModel>(productDTO);
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