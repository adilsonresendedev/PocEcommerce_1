namespace PocEcommerce_1.ViewModels
{
    public class OrderToInsertViewModel
    {
        public int IdUser { get; set; }
        public List<OrderCourseToInsertViewModel> CourseViewModel { get; set; } = default!;
    }
}
