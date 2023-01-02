using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Data.Context;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.Entities;
using PocEcommerce_1.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEcommerce_1.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _appDbContext;
        public ShoppingCartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Update(ShoppingCart shoppingCart)
        {
            _appDbContext.Set<ShoppingCart>().Update(shoppingCart);
            return await _appDbContext.SaveChangesAsync() == 1;
        }

        public async Task<List<ShoppingCart>> GetAll(ShoppingCartFilter shoppingCartFilter)
        {
            IQueryable<ShoppingCart> ShoppingCart = _appDbContext.Set<ShoppingCart>()
                .Where(x => shoppingCartFilter.Id != 0 ? x.Id == shoppingCartFilter.Id : true)
                .Where(x => shoppingCartFilter.IdUser != 0 ? x.IdUser == shoppingCartFilter.IdUser : true)
                .Skip(shoppingCartFilter.Skip)
                .Take(shoppingCartFilter.PageSize);

            List<ShoppingCart> _shoppinCart = await ShoppingCart
                .AsNoTracking()
                .ToListAsync();

            return _shoppinCart;
        }

        public async Task<ShoppingCart> GetById(int id)
        {
            ShoppingCart shoppingCart = await _appDbContext.Set<ShoppingCart>().FirstOrDefaultAsync(x => x.Id == id);
            return shoppingCart;
        }

        public async Task<int> Insert(ShoppingCart shoppingCart)
        {
            await _appDbContext.Set<ShoppingCart>().AddAsync(shoppingCart);
            await _appDbContext.SaveChangesAsync();
            return shoppingCart.Id;
        }
    }
}
