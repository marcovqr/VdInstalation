using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encabezado_Detalle.Migrations
{
    /// <inheritdoc />
    public partial class BD6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "cot_cotizacion_item",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "cot_cotizacion_item",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "cot_cotizacion_item");

            migrationBuilder.DropColumn(
                name: "Store",
                table: "cot_cotizacion_item");
        }
    }
}
