using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IActionResult SearchProductInProducts(string productName)
        {
            List<Product> products = _context.Products.Where(p => p.Name.Contains(productName))
                                                      .ToList();
            return View("Products", products);
        }

        [HttpPost]
        public IActionResult SearchProductInCarts(string productName)
        {
            List<Cart> carts = _context.Carts.Include(cart => cart.Product)
                                                .Where(cart => cart.Product.Name.Contains(productName))
                                                .ToList();

            HomeController.StaticCarts = carts;

            return RedirectToAction("CartsWith", "Home", carts);
        }

        [HttpPost]
        public IActionResult SearchProductInFavorites(string productName)
        {
            List<Favorites> favorites = _context.Favorites.Include(f => f.Product)
                                                        .Where(f => f.Product.Name.Contains(productName))
                                                        .ToList();

            HomeController.StaticFavorites = favorites;

            return RedirectToAction("FavoritesWith", "Home", favorites);
        }

        [HttpPost]
        public IActionResult ProductInfo(string productName)
        {
            Product product = _context.Products.First(p => p.Name == productName);

            ProductInfoModel productInfoModel = new ProductInfoModel()
            {
                Context = _context,
                Product = product
            };

            return View(productInfoModel);
        }

        public IActionResult AddToCart(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Cart newCart = new Cart()
            {
                Product = product,
                UserId = Program.CurrentUser.Id
            };

            _context.Carts.Add(newCart);
            _context.SaveChanges();

            ProductInfoModel productInfoModel = new ProductInfoModel()
            {
                Context = _context,
                Product = product
            };

            return View("ProductInfo", productInfoModel);
        }

        public IActionResult AddToCartFromCartPage(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Cart newCart = new Cart()
            {
                Product = product,
                UserId = Program.CurrentUser.Id
            };

            _context.Carts.Add(newCart);
            _context.SaveChanges();

            return RedirectToAction("Carts", "Home");
        }

        public IActionResult RemoveFromCart(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Cart cart = _context.Carts.FirstOrDefault(x => x.Product == product);

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            ProductInfoModel productInfoModel = new ProductInfoModel()
            {
                Context = _context,
                Product = product
            };
            return View("ProductInfo", productInfoModel);
        }

        public IActionResult RemoveFromCartFromCartPage(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Cart cart = _context.Carts.FirstOrDefault(x => x.Product == product);

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return RedirectToAction("Carts", "Home");
        }

        public IActionResult AddToFavorite(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Favorites newFavorite = new Favorites()
            {
                Product = product,
                UserId = Program.CurrentUser.Id
            };

            _context.Favorites.Add(newFavorite);
            _context.SaveChanges();

            ProductInfoModel productInfoModel = new ProductInfoModel()
            {
                Context = _context,
                Product = product
            };

            return View("ProductInfo", productInfoModel);
        }

        public IActionResult RemoveFromFavorite(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Favorites favorite = _context.Favorites.FirstOrDefault(x => x.Product == product);

            _context.Favorites.Remove(favorite);
            _context.SaveChanges();

            ProductInfoModel productInfoModel = new ProductInfoModel()
            {
                Context = _context,
                Product = product
            };
            return View("ProductInfo", productInfoModel);
        }

        public IActionResult RemoveFromFavoriteFromFavoritePage(string productName)
        {
            var product = _context.Products.First(p => p.Name == productName);

            Favorites favorite = _context.Favorites.FirstOrDefault(x => x.Product == product);

            _context.Favorites.Remove(favorite);
            _context.SaveChanges();

            return RedirectToAction("Favorites", "Home");
        }

        public IActionResult BuyProduct()
        {
            foreach (var entity in _context.Carts)
            {
                _context.Carts.Remove(entity);
            }

            _context.SaveChanges();

            return RedirectToAction("Carts","Home");
        }
    }
}
