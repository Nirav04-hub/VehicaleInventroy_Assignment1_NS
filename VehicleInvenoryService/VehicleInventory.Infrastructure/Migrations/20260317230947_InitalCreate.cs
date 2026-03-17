using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS_VehicleInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleLocations_LocationId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_LocationId",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationId",
                table: "Vehicles",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleLocations_LocationId",
                table: "Vehicles",
                column: "LocationId",
                principalTable: "VehicleLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
