using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMangement.Infrastructure.EFCore.Migrations
{
    public partial class addrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 1, "1401/08/02 16:14:12" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 1, "1401/08/02 16:14:12" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 1, "1401/08/02 16:14:12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 0, "1401/08/02 16:10:05" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 0, "1401/08/02 16:10:05" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cod", "SaveDate" },
                values: new object[] { 0, "1401/08/02 16:10:05" });
        }
    }
}
