using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobsBurgerAPI_v2.Migrations
{
    public partial class FixAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Bairros_BairroId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_BairroId",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_BairroId",
                table: "Clientes",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Bairros_BairroId",
                table: "Clientes",
                column: "BairroId",
                principalTable: "Bairros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
