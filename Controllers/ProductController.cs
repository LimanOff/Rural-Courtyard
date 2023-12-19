using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralCourtyard.Models.Infrastructure;
using RuralCourtyard.Views.ProductController;

namespace RuralCourtyard.Controllers
{
    public class ProductController : Controller
    {
        private readonly DatabaseContext _context;
        public ProductController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Products(string nameOfCategory)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Name == nameOfCategory);

            if (category != null)
            {
                List<Product> products = _context.Products.Include(p => p.Category)
                                                        .Where(p => p.Category == category)
                                                        .ToList();
                return View(products);
            }
            return View(new List<Product>().DefaultIfEmpty<Product>());
        }

        [HttpPost]
        public IActionResult SearchProduct(string productName)
        {
            List<Product> products = _context.Products.Where(p => p.Name.Contains(productName))
                                                        .ToList();
            return View("Products", products);
        }

        [HttpPost]
        public IActionResult ProductInfo(string productName)
        {
            Product product = _context.Products.First(p => p.Name == productName);
            return View(product);
        }
    }
}
