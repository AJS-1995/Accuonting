using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMangement.Infrastructure.EFCore.Migrations
{
    public partial class addmoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISO_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Moneys",
                columns: new[] { "Id", "Active", "Country", "ISO_Code", "Name", "SaveDate", "Slug", "Status", "Symbol", "User_Id" },
                values: new object[,]
                {
                    { 1, true, "افغانستان", "AFN", "افغانی", "1401/08/02 16:10:51", "افغانی", true, "؋", 1 },
                    { 2, true, "ایران", "IRR", "ریال", "1401/08/02 16:10:51", "ریال", true, "ریال", 1 },
                    { 3, true, "چین", "CNY", "یوآن", "1401/08/02 16:10:51", "یوآن", true, "¥", 1 },
                    { 4, true, "هندوستان", "INR", "روپیه", "1401/08/02 16:10:51", "روپیه", true, "₹", 1 },
                    { 5, true, "پاکستان", "PKR", "روپیه", "1401/08/02 16:10:51", "روپیه", true, "₨", 1 },
                    { 6, true, "اروپا", "EUR", "یورو", "1401/08/02 16:10:51", "یورو", true, "€", 1 },
                    { 7, true, "بریتانیا", "GBP", "پوند", "1401/08/02 16:10:51", "پوند", true, "£", 1 },
                    { 8, true, "ایالات متحده امریکا", "USD", "دلار", "1401/08/02 16:10:51", "دلار", true, "$", 1 },
                    { 9, true, "ترکیه", "TRY", "لیره", "1401/08/02 16:10:51", "لیره", true, "₺", 1 },
                    { 10, true, "روسیه", "RUB", "روبل", "1401/08/02 16:10:51", "روبل", true, "₽", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moneys");
        }
    }
}
