using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Data.EntityConfiguration 
{
    public class OrderCourseConfiguration : IEntityTypeConfiguration<OrderCourse>
    {
        public void Configure(EntityTypeBuilder<OrderCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.OrderCourse)
                .HasForeignKey(x => x.IdCourse)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderCourse)
                .HasForeignKey(x => x.IdOrder)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}