namespace PocEcommerce_1.Entities
{
    public class Course : BaseEntity
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public virtual List<OrderCourse> ShoppingCartCourse { get; set; } = default!;
    }
}
