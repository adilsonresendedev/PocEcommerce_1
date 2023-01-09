namespace PocEcommerce_1.Entities
{
    public class Course : BaseEntity
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public virtual List<OrderCourse> OrderCourse { get; set; } = default!;
        public virtual List<User> User { get; set; } = default!;
    }
}
