namespace PocEcommerce_1.Shared.Filters
{
    public class ProductFilter : BaseFilter
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
    }
}
