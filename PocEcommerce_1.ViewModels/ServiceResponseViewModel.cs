namespace PocEcommerce_1.ViewModels
{
    public class ServiceResponseViewModel<T>
    {
        public T Data { get; set;  } = default!;
        public PaginationDTO pagination { get; set; } = default!;
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; } = default!;
    }
}