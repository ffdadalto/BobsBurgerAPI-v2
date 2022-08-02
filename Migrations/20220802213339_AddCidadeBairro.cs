using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobsBurgerAPI_v2.Migrations
{
    public partial class AddCidadeBairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Situacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CriadodEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CriadodEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditadoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_CidadeId",
                table: "Bairros",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Situacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
