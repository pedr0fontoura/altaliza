using Microsoft.EntityFrameworkCore.Migrations;

namespace Altaliza.Infra.Migrations
{
    public partial class AddReverseRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_vehicles_characters_CharacterId",
                table: "characters_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_characters_vehicles_vehicles_VehicleId",
                table: "characters_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_vehicles_categories_CategoryId",
                table: "vehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_vehicles_characters_CharacterId",
                table: "characters_vehicles",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_characters_vehicles_vehicles_VehicleId",
                table: "characters_vehicles",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_vehicles_categories_CategoryId",
                table: "vehicles",
                column: "CategoryId",
                principalTable: "vehicles_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_vehicles_characters_CharacterId",
                table: "characters_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_characters_vehicles_vehicles_VehicleId",
                table: "characters_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_vehicles_categories_CategoryId",
                table: "vehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_vehicles_characters_CharacterId",
                table: "characters_vehicles",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_characters_vehicles_vehicles_VehicleId",
                table: "characters_vehicles",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_vehicles_categories_CategoryId",
                table: "vehicles",
                column: "CategoryId",
                principalTable: "vehicles_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
