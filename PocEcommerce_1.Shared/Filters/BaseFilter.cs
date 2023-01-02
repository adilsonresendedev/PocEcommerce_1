namespace PocEcommerce_1.Shared.Filters
{
    public class BaseFilter
    {
        public int Id { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public int Skip { get { return CurrentPage > 1 ? (CurrentPage - 1) * PageSize : 0; } set { } }
    }
}
