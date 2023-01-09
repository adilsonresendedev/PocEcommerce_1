namespace PocEcommerce_1.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public int IdUser { get; set; }
        public List<CourseViewModel> CourseViewModel { get; set; } = default!;
    }
}
