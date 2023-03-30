using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargingStationAPI.Migrations
{
    public partial class addnewpropertiestoChargingStationclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Infomation",
                table: "ChargingStations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "ChargingStations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "ChargingStations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalChargerPorts",
                table: "ChargingStations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infomation",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "TotalChargerPorts",
                table: "ChargingStations");
        }
    }
}
