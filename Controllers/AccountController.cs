using Microsoft.AspNetCore.Mvc;
using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;
        public AccountController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult GoToIndex() => RedirectToAction("Index", "Home");

        [HttpGet]
        public IActionResult Registration() => View();
        [HttpGet]
        public IActionResult Authorization() => View();

        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            if (login != null && password != null)
            {
                User user = new User() { Login = login, Password = password };

                bool IsUserAlreadyExist = _context.Users.ToList().FirstOrDefault(x => x.Login == user.Login
                                                                             &&
                                                                             x.Password == user.Password)
                                                                             != null;

                if (!IsUserAlreadyExist)
                {
                    _context.Users.Add(user);
                    _context.SaveChangesAsync();

                    Program.CurrentUser = _context.Users.First(x => x.Login == user.Login
                                                                             &&
                                                                             x.Password == user.Password);
                    return GoToIndex();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            if (login != null && password != null)
            {
                User? user = _context.Users.ToList().FirstOrDefault(x => x.Login == login
                                                                             &&
                                                                             x.Password == password);

                bool IsUserAlreadyExist = user != null;

                if (IsUserAlreadyExist)
                {
                    Program.CurrentUser = user;
                    return GoToIndex();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Program.CurrentUser = null;
            return RedirectToAction("Registration");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return RedirectToAction("Authorization");
        }
    }
}
