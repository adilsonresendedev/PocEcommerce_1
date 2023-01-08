namespace PocEcommerce_1.ViewModels
{
    public class ShoppingCartToInsertViewModel
    {
        public int IdUser { get; set; }
        public int IdCourse { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
