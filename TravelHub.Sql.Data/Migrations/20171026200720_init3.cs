using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelHub.Sql.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportCodeId",
                table: "Airports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AirportCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportCodes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportCodeId",
                table: "Airports",
                column: "AirportCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportCodes_CityId",
                table: "AirportCodes",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_AirportCodes_AirportCodeId",
                table: "Airports",
                column: "AirportCodeId",
                principalTable: "AirportCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_AirportCodes_AirportCodeId",
                table: "Airports");

            migrationBuilder.DropTable(
                name: "AirportCodes");

            migrationBuilder.DropIndex(
                name: "IX_Airports_AirportCodeId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "AirportCodeId",
                table: "Airports");
        }
    }
}
