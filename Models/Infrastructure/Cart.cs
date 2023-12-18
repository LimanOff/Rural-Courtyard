namespace RuralCourtyard.Models.Infrastructure
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}