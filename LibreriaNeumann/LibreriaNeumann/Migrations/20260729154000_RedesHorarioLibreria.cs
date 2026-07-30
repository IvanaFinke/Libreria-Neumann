using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaNeumann.Migrations
{
    /// <inheritdoc />
    public partial class RedesHorarioLibreria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Libreria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicio",
                table: "Libreria",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraSalida",
                table: "Libreria",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Libreria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tiktok",
                table: "Libreria",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Libreria");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Libreria");

            migrationBuilder.DropColumn(
                name: "HoraSalida",
                table: "Libreria");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Libreria");

            migrationBuilder.DropColumn(
                name: "Tiktok",
                table: "Libreria");
        }
    }
}
