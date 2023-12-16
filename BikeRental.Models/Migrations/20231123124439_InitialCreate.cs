using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRental.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrameSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrameSizeId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartService = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsInService = table.Column<bool>(type: "bit", nullable: false),
                    IsRent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bicycles_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bicycles_FrameSizes_FrameSizeId",
                        column: x => x.FrameSizeId,
                        principalTable: "FrameSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicycleId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationTickets_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_CategoryId",
                table: "Bicycles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_FrameSizeId",
                table: "Bicycles",
                column: "FrameSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTickets_BicycleId",
                table: "ReservationTickets",
                column: "BicycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationTickets");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "FrameSizes");
        }
    }
}
