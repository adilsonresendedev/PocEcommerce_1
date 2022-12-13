namespace PocEcommerce_1.Entities
{
    public class Product : BaseEntity
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
