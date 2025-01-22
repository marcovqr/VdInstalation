using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encabezado_Detalle.Migrations
{
    /// <inheritdoc />
    public partial class BD1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_persona",
                table: "cot_cotizacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cot_cotizacion_id_persona",
                table: "cot_cotizacion",
                column: "id_persona");

            migrationBuilder.AddForeignKey(
                name: "FK_cot_cotizacion_persona_id_persona",
                table: "cot_cotizacion",
                column: "id_persona",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cot_cotizacion_persona_id_persona",
                table: "cot_cotizacion");

            migrationBuilder.DropIndex(
                name: "IX_cot_cotizacion_id_persona",
                table: "cot_cotizacion");

            migrationBuilder.DropColumn(
                name: "id_persona",
                table: "cot_cotizacion");
        }
    }
}
