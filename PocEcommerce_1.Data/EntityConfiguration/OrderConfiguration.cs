using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.ShoppingCarts)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
