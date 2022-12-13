using PocEcommerce_1.DTOs;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponseDTO<UserLoginViewModel>> Register(UserToInsertViewModel userToInsertViewModel);

        public Task<ServiceResponseDTO<string>> Login(UserLoginViewModel userLoginViewModel);
    }
}
