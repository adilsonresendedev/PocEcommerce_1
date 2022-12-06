namespace PocEcommerce_1.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}