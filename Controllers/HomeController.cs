using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View();

        public IActionResult Products(string nameOfCategory)
        {
            var category = _context.Categories.First(x => x.Name == nameOfCategory);

            List<Product> products = _context.Products.Include(p => p.Category)
                                                        .Where(p => p.Category == category)
                                                        .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Cart() => View(_context);

        [HttpGet]
        public IActionResult Favorites() => View(_context);

        [HttpGet]
        public IActionResult Categories() => View(_context);

        [HttpGet]
        public IActionResult Contacts() => View();
    }
}
