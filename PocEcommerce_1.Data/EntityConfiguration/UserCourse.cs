using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.EntityConfiguration
{
    public class UserCourse : IEntityTypeConfiguration<OrderCourse>
    {
        public void Configure(EntityTypeBuilder<OrderCourse> builder)
        {
            builder.HasKey(x => x.IdShoppingCart);
            builder.HasOne(x => x.ShoppingCart)
                .WithMany(x => x.OrderCourse)
                .HasForeignKey(x => x.IdShoppingCart)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.ShoppingCartCourse)
                .HasForeignKey(x => x.IdCourse)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
