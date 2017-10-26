using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelHub.Sql.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_AirportCode_AirportCodeAirportId_AirportCodeCityId",
                table: "Airports");

            migrationBuilder.DropTable(
                name: "AirportCode");

            migrationBuilder.DropIndex(
                name: "IX_Airports_AirportCodeAirportId_AirportCodeCityId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "AirportCodeAirportId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "AirportCodeCityId",
                table: "Airports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportCodeAirportId",
                table: "Airports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportCodeCityId",
                table: "Airports",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AirportCode",
                columns: table => new
                {
                    AirportId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCode", x => new { x.AirportId, x.CityId });
                    table.ForeignKey(
                        name: "FK_AirportCode_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportCodeAirportId_AirportCodeCityId",
                table: "Airports",
                columns: new[] { "AirportCodeAirportId", "AirportCodeCityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AirportCode_CityId",
                table: "AirportCode",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_AirportCode_AirportCodeAirportId_AirportCodeCityId",
                table: "Airports",
                columns: new[] { "AirportCodeAirportId", "AirportCodeCityId" },
                principalTable: "AirportCode",
                principalColumns: new[] { "AirportId", "CityId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
