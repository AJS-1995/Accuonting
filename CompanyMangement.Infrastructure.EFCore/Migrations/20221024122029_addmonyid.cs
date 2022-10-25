using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyMangement.Infrastructure.EFCore.Migrations
{
    public partial class addmonyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoneyId",
                table: "Companys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyId",
                table: "Companys");
        }
    }
}
