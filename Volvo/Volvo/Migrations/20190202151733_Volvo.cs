using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo.Migrations
{
    public partial class Volvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Chassis = table.Column<string>(nullable: false),
                    ManufactureYear = table.Column<DateTime>(nullable: false),
                    DateTimeCreate = table.Column<DateTime>(nullable: false),
                    DateTimeModification = table.Column<DateTime>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TruckModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TruckId = table.Column<Guid>(nullable: false),
                    ModelYear = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    Potence = table.Column<string>(nullable: true),
                    DateTimeCreate = table.Column<DateTime>(nullable: false),
                    DateTimeModification = table.Column<DateTime>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModel", x => new { x.Id, x.TruckId });
                    table.UniqueConstraint("AK_TruckModel_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckModel_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckModel_TruckId",
                table: "TruckModel",
                column: "TruckId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckModel");

            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
