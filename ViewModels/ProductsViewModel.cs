using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.ViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories{ get; set; }
        public string LastSearch { get; set; }
    }
}
