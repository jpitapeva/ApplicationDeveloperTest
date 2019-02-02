using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo.Migrations
{
    public partial class Volvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TruckModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TruckModelId = table.Column<Guid>(nullable: false),
                    Chassis = table.Column<string>(nullable: false),
                    ManufactureYear = table.Column<DateTime>(nullable: false),
                    DateTimeCreate = table.Column<DateTime>(nullable: false),
                    DateTimeModification = table.Column<DateTime>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => new { x.Id, x.TruckModelId });
                    table.UniqueConstraint("AK_Truck_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truck_TruckModel_TruckModelId",
                        column: x => x.TruckModelId,
                        principalTable: "TruckModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_TruckModelId",
                table: "Truck",
                column: "TruckModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "TruckModel");
        }
    }
}
