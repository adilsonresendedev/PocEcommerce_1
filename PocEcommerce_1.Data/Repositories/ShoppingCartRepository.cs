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

        public async Task<bool> Update(Order shoppingCart)
        {
            _appDbContext.Set<Order>().Update(shoppingCart);
            return await _appDbContext.SaveChangesAsync() == 1;
        }

        public async Task<List<Order>> GetAll(ShoppingCartFilter shoppingCartFilter)
        {
            IQueryable<Order> ShoppingCart = _appDbContext.Set<Order>()
                .Where(x => shoppingCartFilter.Id != 0 ? x.Id == shoppingCartFilter.Id : true)
                .Where(x => shoppingCartFilter.IdUser != 0 ? x.IdUser == shoppingCartFilter.IdUser : true)
                .Skip(shoppingCartFilter.Skip)
                .Take(shoppingCartFilter.PageSize);

            List<Order> _shoppinCart = await ShoppingCart
                .AsNoTracking()
                .ToListAsync();

            return _shoppinCart;
        }

        public async Task<Order> GetById(int id)
        {
            Order shoppingCart = await _appDbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == id);
            return shoppingCart;
        }

        public async Task<int> Insert(Order shoppingCart)
        {
            await _appDbContext.Set<Order>().AddAsync(shoppingCart);
            await _appDbContext.SaveChangesAsync();
            return shoppingCart.Id;
        }
    }
}
