namespace PocEcommerce_1.DTOs
{
    public class CourseDTO : BaseDTO
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}