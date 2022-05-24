using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.API.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_TravelTrips_TripId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "TravelFlights");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_TripId",
                table: "TravelFlights",
                newName: "IX_TravelFlights_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelFlights",
                table: "TravelFlights",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelFlights_TravelTrips_TripId",
                table: "TravelFlights",
                column: "TripId",
                principalTable: "TravelTrips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelFlights_TravelTrips_TripId",
                table: "TravelFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelFlights",
                table: "TravelFlights");

            migrationBuilder.RenameTable(
                name: "TravelFlights",
                newName: "Flight");

            migrationBuilder.RenameIndex(
                name: "IX_TravelFlights_TripId",
                table: "Flight",
                newName: "IX_Flight_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_TravelTrips_TripId",
                table: "Flight",
                column: "TripId",
                principalTable: "TravelTrips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
