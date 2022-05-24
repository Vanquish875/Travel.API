using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelActivities_TravelCities_CityId",
                table: "TravelActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelBoardings_TravelCities_CityId",
                table: "TravelBoardings");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelCities_TravelTrips_TripId",
                table: "TravelCities");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TravelCities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TravelBoardings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TravelActivities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelActivities_TravelCities_CityId",
                table: "TravelActivities",
                column: "CityId",
                principalTable: "TravelCities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelBoardings_TravelCities_CityId",
                table: "TravelBoardings",
                column: "CityId",
                principalTable: "TravelCities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelCities_TravelTrips_TripId",
                table: "TravelCities",
                column: "TripId",
                principalTable: "TravelTrips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelActivities_TravelCities_CityId",
                table: "TravelActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelBoardings_TravelCities_CityId",
                table: "TravelBoardings");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelCities_TravelTrips_TripId",
                table: "TravelCities");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TravelCities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TravelBoardings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TravelActivities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelActivities_TravelCities_CityId",
                table: "TravelActivities",
                column: "CityId",
                principalTable: "TravelCities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelBoardings_TravelCities_CityId",
                table: "TravelBoardings",
                column: "CityId",
                principalTable: "TravelCities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelCities_TravelTrips_TripId",
                table: "TravelCities",
                column: "TripId",
                principalTable: "TravelTrips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
