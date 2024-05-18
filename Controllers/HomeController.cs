using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public static List<Cart> StaticCarts;
        public static List<Favorites> StaticFavorites;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Carts()
        {
            List<Cart> carts = _context.Carts.Include(x => x.Product).ToList();
            return View(carts);
        }

        [HttpGet]
        public IActionResult CartsWith()
        {
            if (StaticCarts.Count != 0)
                return View("Carts", StaticCarts);
            else
                return RedirectToAction("Carts");
        }


        [HttpGet]
        public IActionResult Favorites()
        {
            List<Favorites> favorites = _context.Favorites.Include(x => x.Product).ToList();
            return View(favorites);
        }

        [HttpGet]
        public IActionResult FavoritesWith()
        {
            if (StaticFavorites.Count != 0)
                return View("Favorites", StaticFavorites);
            else
                return RedirectToAction("Favorites");
        }

        [HttpGet]
        public IActionResult Categories() => View(_context);

        [HttpGet]
        public IActionResult Contacts() => View();
    }
}
