namespace PocEcommerce_1.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public int IdUser { get; set; }
        public List<CourseDTO> CourseDTO { get; set; } = default!;
        public decimal PricePaid { get; set; }
        public DateTime DateAdded { get; set; }
    }
}