using Microsoft.EntityFrameworkCore;
using RuralCourtyard.Models.Infrastructure;

namespace RuralCourtyard
{
    public class Program
    {
        public static User CurrentUser;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string dbConnectionString = builder.Configuration.GetConnectionString("DbHome");

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(dbConnectionString));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}