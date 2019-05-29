using Microsoft.EntityFrameworkCore.Migrations;

namespace TrestlebridgeEntity.Data.Migrations
{
    public partial class FacilitiesAttachedToFarms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Facilities",
                nullable: false,
                defaultValue: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FarmId",
                table: "Facilities",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Farms_FarmId",
                table: "Facilities",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Farms_FarmId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_FarmId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Facilities");
        }
    }
}
