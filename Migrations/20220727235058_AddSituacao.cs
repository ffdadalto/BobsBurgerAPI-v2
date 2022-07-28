using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobsBurgerAPI_v2.Migrations
{
    public partial class AddSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CriadodEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
