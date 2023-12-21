using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            ParsingDataToProducts("products.csv");
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

        private void ParsingDataToProducts(string nameOfFile)
        {
            string path = @$"../RuralCourtyard/DataForParsing/Products/{nameOfFile}";

            var lines = File.ReadAllLines(path).Select(x => x.Trim()).ToList();

            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var columns = line.Split(';');

                Product p = new Product()
                {
                    Id = Int32.Parse(columns[0]),
                    CategoryId = Int32.Parse(columns[1]),
                    Name = columns[2],
                    Description = columns[3],
                    Color = columns[4],
                    ImageLink = columns[5],
                    Cost = Decimal.Parse(columns[6])
                };

                Products.Add(p);
            }

            SaveChanges();
        }
    }
}
