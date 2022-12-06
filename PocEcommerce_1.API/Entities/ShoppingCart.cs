using Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocEcommerce_1.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        [ForeignKey(nameof(IdUser))]
        public virtual User User { get; set; } = default!;
        [ForeignKey(nameof(IdProduct))]
        public virtual Product Product { get; set; } = default!;
    }
}
