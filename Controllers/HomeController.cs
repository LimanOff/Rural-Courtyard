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

        [HttpGet]
        public IActionResult Cart() => View();

        [HttpGet]
        public IActionResult Favorites() => View();
        [HttpGet]
        public IActionResult Contacts() => View();
    }
}
