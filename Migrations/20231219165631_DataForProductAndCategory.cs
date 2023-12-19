using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RuralCourtyard.Migrations
{
    /// <inheritdoc />
    public partial class DataForProductAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Розы" },
                    { 2, "Хризантемы" },
                    { 3, "Пионы" },
                    { 4, "Лилии" },
                    { 5, "Орхидеи" },
                    { 6, "Полевые" },
                    { 7, "Астры" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Cost", "Description", "ImageLink", "Name" },
                values: new object[] { 1, 1, "red", 300m, "Зимостойкое, устойчивое к болезням кустистое растение с чашевидными ярко-розовыми цветками диаметром 8–10 см. Цвести роза начинает рано (в начале лета) и продолжает благоухать до поздней осени. В аромате чувствуются тонкие нотки меда и миндаля.Почва: Розы любят нейтральный (рН 6), богатый гумусом, умеренно-влажный и рыхлый грунт.Место посадки: Пионовидные розы предпочитают полутень. При этом участок должен освещаться солнечными лучам не менее 3 часов в сутки. Под большими деревьями или на северной стороне здания растение цвести практически не будет.Подкормка: Пионовидным розам требуются минеральные удобрения, содержащие азот, фосфор, калий, магний, железо и микроэлементы. В первой половине лета вносите азотные удобрения, в период формирования бутонов — фосфор и калий, свежий навоз.Цветение: зацветают в конце мая–начале июня. ", "mary-rose.png", "Мэри роуз" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
