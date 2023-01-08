using Microsoft.EntityFrameworkCore;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public List<User> Users { get; set; } = default!;
        public List<Order> ShoppingCarts { get; set; } = default!;
        public List<Course> Products { get; set; } = default!; 
        public List<OrderCourse> shoppingCartProducts { get; set; } = default!;
    }
}
