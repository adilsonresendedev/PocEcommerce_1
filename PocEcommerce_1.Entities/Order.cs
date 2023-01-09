namespace PocEcommerce_1.Entities
{
    public class Order : BaseEntity
    {
        public int IdUser { get; set; }
        public virtual User User { get; set; } = default!;
        public virtual List<OrderCourse> OrderCourse { get; set; } = default!;
    }
}
