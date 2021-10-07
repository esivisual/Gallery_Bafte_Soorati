using Microsoft.EntityFrameworkCore.Migrations;

namespace Gallery_Bafte_Soorati.Presistance.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orderState",
                table: "Orders",
                newName: "OrderState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderState",
                table: "Orders",
                newName: "orderState");
        }
    }
}
