using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.Entities;


namespace PocEcommerce_1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
