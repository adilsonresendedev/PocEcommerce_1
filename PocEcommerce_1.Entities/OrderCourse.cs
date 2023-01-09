namespace PocEcommerce_1.Entities
{
    public class OrderCourse : BaseEntity
    {
        public int IdOrder { get; set; }
        public virtual Order Order { get; set; } = default!;
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRemoved { get; set; }
    }
}
