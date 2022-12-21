namespace PocEcommerce_1.ViewModels
{
    public class PaginationViewModel
    {
        public int Page { get; set; } = 1;
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 100;
        public int TotalRecords { get; set; }
    }
}