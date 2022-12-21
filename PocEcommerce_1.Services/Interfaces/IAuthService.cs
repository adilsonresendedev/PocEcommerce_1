using PocEcommerce_1.DTOs;
using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel);

        public Task<ServiceResponseViewModel<string>> Login(UserViewModel userLoginViewModel);
    }
}
