namespace PocEcommerce_1.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public int IdUser { get; set; }
        public int IdShoppingCart { get; set; }
        public decimal PricePaid { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
