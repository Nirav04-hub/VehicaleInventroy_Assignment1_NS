using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS_VehicleInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedDDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocations", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleLocations_LocationId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleLocations");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_LocationId",
                table: "Vehicles");
        }
    }
}
