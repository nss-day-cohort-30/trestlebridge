using Microsoft.EntityFrameworkCore.Migrations;

namespace TrestlebridgeEntity.Data.Migrations
{
    public partial class AddedAcres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Acres",
                table: "Farms",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acres",
                table: "Farms");
        }
    }
}
