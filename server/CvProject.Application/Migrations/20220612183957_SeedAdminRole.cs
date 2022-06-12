using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvProject.Application.Migrations
{
    public partial class SeedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8379b26b-6abb-4cde-b775-e002a57bfe33", "5125fa7f-cf5c-434a-a20e-6aa0f4d41b74", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8379b26b-6abb-4cde-b775-e002a57bfe33");
        }
    }
}
