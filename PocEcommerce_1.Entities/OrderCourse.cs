namespace PocEcommerce_1.Entities
{
    public class OrderCourse
    {
        public bool IsActive { get; set; }
        public int IdShoppingCart { get; set; }
        public virtual Order ShoppingCart { get; set; } = default!;
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRemoved { get; set; }
    }
}
