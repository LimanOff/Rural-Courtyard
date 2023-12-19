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
        }
    }
}
