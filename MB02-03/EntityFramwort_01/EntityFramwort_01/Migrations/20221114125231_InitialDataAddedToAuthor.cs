using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    public partial class InitialDataAddedToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "City", "Level", "Name", "Phone", "Salary" },
                values: new object[] { 10, null, 0, "Max", null, 29328.23m });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "City", "Level", "Name", "Phone", "Salary" },
                values: new object[] { 20, null, 0, "Fritzli", null, 216.23m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
