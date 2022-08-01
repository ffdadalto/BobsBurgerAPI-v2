using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobsBurgerAPI_v2.Migrations
{
    public partial class AdicaoCorSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Situacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Situacoes");
        }
    }
}
