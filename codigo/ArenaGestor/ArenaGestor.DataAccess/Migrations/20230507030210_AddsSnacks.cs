using Microsoft.EntityFrameworkCore.Migrations;

namespace ArenaGestor.DataAccess.Migrations
{
    public partial class AddsSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.SnackId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snack_SnackId",
                table: "Snack",
                column: "SnackId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snack");
        }
    }
}
