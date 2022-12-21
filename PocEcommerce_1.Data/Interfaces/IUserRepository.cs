using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Insert(User user);

        Task<User> Update(User user);

        Task<User> GetByEmail(string email);
    }
}
