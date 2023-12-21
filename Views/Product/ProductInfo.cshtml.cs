using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.Views.ProductController
{
    public class ProductInfoModel : PageModel
    {
        public DatabaseContext Context { get; set; }
        public Product Product { get; set; }
    }
}
