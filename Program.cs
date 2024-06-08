using Microsoft.EntityFrameworkCore;
using RuralCourtyard.Models.Infrastructure;

using System.Reflection;

namespace RuralCourtyard
{
    public class Program
    {
        public static User CurrentUser;
        public static string RootFolder {get; private set;}

        private const string DbHomeConnection = "DbHome";
        private const string DbHAKVTConnection = "DbAKVT";

        public static void Main(string[] args)
        {
            RootFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString()).ToString()).ToString()).ToString();
            var builder = WebApplication.CreateBuilder(args);

            string dbConnectionString = builder.Configuration.GetConnectionString(DbHomeConnection);

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(dbConnectionString));

            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();
            builder.Services.AddMvc();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}