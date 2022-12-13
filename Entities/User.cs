namespace PocEcommerce_1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public virtual List<ShoppingCart> ShoppingCarts { get; set; } = default!;
    }
}