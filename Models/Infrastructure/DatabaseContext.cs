using Microsoft.EntityFrameworkCore;

namespace RuralCourtyard.Models.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category roses = new Category() { Id = 1, Name = "Розы" };
            Category chrysanthemums = new Category() { Id = 2, Name = "Хризантемы" };
            Category pions = new Category() { Id = 3, Name = "Пионы" };
            Category lilies = new Category() { Id = 4, Name = "Лилии" };
            Category orchids = new Category() { Id = 5, Name = "Орхидеи" };
            Category field = new Category() { Id = 6, Name = "Полевые" };
            Category asters = new Category() { Id = 7, Name = "Астры" };

            modelBuilder.Entity<Category>().HasData(roses,chrysanthemums,pions,lilies,orchids,field,asters);

            Product p1 = new Product() { Id = 1, CategoryId = roses.Id, Color = "red", Cost = 300, Description = "Зимостойкое, устойчивое к болезням кустистое растение с чашевидными ярко-розовыми цветками диаметром 8–10 см. Цвести роза начинает рано (в начале лета) и продолжает благоухать до поздней осени. В аромате чувствуются тонкие нотки меда и миндаля." +
                "Почва: Розы любят нейтральный (рН 6), богатый гумусом, умеренно-влажный и рыхлый грунт." +
                "Место посадки: Пионовидные розы предпочитают полутень. При этом участок должен освещаться солнечными лучам не менее 3 часов в сутки. Под большими деревьями или на северной стороне здания растение цвести практически не будет." +
                "Подкормка: Пионовидным розам требуются минеральные удобрения, содержащие азот, фосфор, калий, магний, железо и микроэлементы. В первой половине лета вносите азотные удобрения, в период формирования бутонов — фосфор и калий, свежий навоз." +
                "Цветение: зацветают в конце мая–начале июня. ",
                ImageLink = "mary-rose.png",
                Name = "Мэри роуз"
            };

            modelBuilder.Entity<Product>().HasData(p1);
        }
    }
}
