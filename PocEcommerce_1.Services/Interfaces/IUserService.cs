using PocEcommerce_1.ViewModels;

namespace PocEcommerce_1.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponseViewModel<UserViewModel>> Update(UserViewModel userViewModel);

        Task<ServiceResponseViewModel<UserViewModel>> Delete(UserViewModel userViewModel);
    }
}
