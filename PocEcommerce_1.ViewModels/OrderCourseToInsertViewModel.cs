namespace PocEcommerce_1.ViewModels
{
    public class OrderCourseToInsertViewModel
    {
        public int IdCourse { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRemoved { get; set; }
    }
}
