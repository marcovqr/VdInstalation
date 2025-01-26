using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encabezado_Detalle.Migrations
{
    /// <inheritdoc />
    public partial class BD8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "cot_cotizacion",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customer",
                table: "cot_cotizacion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telf",
                table: "cot_cotizacion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adress",
                table: "cot_cotizacion");

            migrationBuilder.DropColumn(
                name: "customer",
                table: "cot_cotizacion");

            migrationBuilder.DropColumn(
                name: "telf",
                table: "cot_cotizacion");
        }
    }
}
