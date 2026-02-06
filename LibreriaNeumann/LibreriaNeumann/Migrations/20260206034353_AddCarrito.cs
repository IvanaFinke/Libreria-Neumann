using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaNeumann.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_UserId",
                table: "Libros",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Users_UserId",
                table: "Libros",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Users_UserId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_UserId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Libros");
        }
    }
}
