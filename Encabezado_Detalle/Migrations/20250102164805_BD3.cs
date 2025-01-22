using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encabezado_Detalle.Migrations
{
    /// <inheritdoc />
    public partial class BD3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "persona",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "persona",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo_cliente",
                table: "persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_PersonaId",
                table: "persona",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_persona_PersonaId",
                table: "persona",
                column: "PersonaId",
                principalTable: "persona",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persona_persona_PersonaId",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_persona_PersonaId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "tipo_cliente",
                table: "persona");
        }
    }
}
