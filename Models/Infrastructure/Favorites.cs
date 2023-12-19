namespace RuralCourtyard.Models.Infrastructure
{
    public class Favorites
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}