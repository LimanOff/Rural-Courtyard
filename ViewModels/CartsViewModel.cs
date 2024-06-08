using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard.ViewModels
{
    public class CartsViewModel
    {
        public List<Cart> Carts { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


        public bool IsPhoneNumberFullWrite()
        {
            return Phone.Count(Char.IsDigit) == 11;
        }
    }
}
