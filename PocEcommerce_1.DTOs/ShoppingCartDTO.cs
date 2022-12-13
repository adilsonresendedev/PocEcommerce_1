namespace PocEcommerce_1.DTOs
{
    public class ShoppingCartDTO 
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public decimal PricePaid { get; set; }
        public DateTime DateAdded { get; set; }
    }
}