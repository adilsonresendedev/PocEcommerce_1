using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Data.Context;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.Entities;


namespace PocEcommerce_1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = await  _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<int> Insert(User user)
        {
            await _appDbContext.Set<User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User> Update(User user)
        {
            _appDbContext.Set<User>().Update(user);
            await _appDbContext.SaveChangesAsync();
            User updatedUser = await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == user.Id);
            return updatedUser;
        }
    }
}
