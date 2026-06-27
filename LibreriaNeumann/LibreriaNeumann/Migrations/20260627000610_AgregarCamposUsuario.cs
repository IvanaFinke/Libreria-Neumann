using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaNeumann.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioCuotas",
                table: "Libros");

            migrationBuilder.AddColumn<string>(
                name: "alturaCalle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "calle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localidad",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alturaCalle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "calle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "localidad",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "Users");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioCuotas",
                table: "Libros",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
