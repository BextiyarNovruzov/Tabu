using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabu.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[] { "Az", "https://www.google.com/imgres?q=Azerbaijani%20flag&imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fd%2Fdd%2FFlag_of_Azerbaijan.svg%2F1200px-Flag_of_Azerbaijan.svg.png&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFlag_of_Azerbaijan&docid=mVnN4VXAhdmFoM&tbnid=i-LWaprbfLW65M&vet=12ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA..i&w=1200&h=600&hcb=2&ved=2ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA", "Azerbaycanca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "Az");
        }
    }
}
