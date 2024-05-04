using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationId",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "PickUpLocationId",
                table: "RentACars",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_PickUpLocationId",
                table: "RentACars",
                newName: "IX_RentACars_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "RentACars",
                newName: "PickUpLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                newName: "IX_RentACars_PickUpLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationId",
                table: "RentACars",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
