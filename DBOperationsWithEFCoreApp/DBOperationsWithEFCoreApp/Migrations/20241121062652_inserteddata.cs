using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBOperationsWithEFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class inserteddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "Tarique.Zaib@gmail.com", "Tarique", "Zaib" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
