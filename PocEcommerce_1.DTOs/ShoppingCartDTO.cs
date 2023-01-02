namespace PocEcommerce_1.DTOs
{
    public class ShoppingCartDTO  : BaseDTO
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public decimal PricePaid { get; set; }
        public DateTime DateAdded { get; set; }
    }
}