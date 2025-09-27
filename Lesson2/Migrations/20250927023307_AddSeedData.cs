using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson2.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "A novel set in the Jazz Age that tells the story of Jay Gatsby's unrequited love for Daisy Buchanan.", 10.99m, "The Great Gatsby" },
                    { 2, "Harper Lee", "A novel about racial injustice in the Deep South, seen through the eyes of young Scout Finch.", 8.99m, "To Kill a Mockingbird" },
                    { 3, "George Orwell", "A dystopian novel that explores themes of totalitarianism, surveillance, and individuality.", 9.99m, "1984" },
                    { 4, "Jane Austen", "A classic romance novel that delves into issues of class, marriage, and societal expectations in 19th-century England.", 7.99m, "Pride and Prejudice" },
                    { 5, "J.D. Salinger", "A coming-of-age novel that follows the experiences of Holden Caulfield as he navigates adolescence and alienation.", 6.99m, "The Catcher in the Rye" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
