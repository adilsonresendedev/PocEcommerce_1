namespace PocEcommerce_1.Shared.Filters
{
    public class CourseFilter : BaseFilter
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
    }
}
