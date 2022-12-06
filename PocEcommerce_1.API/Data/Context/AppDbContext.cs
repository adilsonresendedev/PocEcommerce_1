using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public List<User> Users { get; set; } = default!;
        public List<ShoppingCart> ShoppingCarts { get; set; } = default!;
        public List<Product> Products { get; set; } = default!; 
    }
}
