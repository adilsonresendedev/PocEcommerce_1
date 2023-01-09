namespace PocEcommerce_1.DTOs
{
    public class OrderCourseDTO : BaseDTO
    {
        public int IdUser { get; set; }
        public virtual OrderDTO OrderDTO { get; set; } = default!;
        public int IdCourse { get; set; }
        public virtual CourseDTO CourseDTO { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRemoved { get; set; }
    }
}
