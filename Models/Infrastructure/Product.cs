namespace RuralCourtyard.Models.Infrastructure
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category{ get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string ImageLink { get; set; }
        public decimal Cost { get; set; }
    }
}