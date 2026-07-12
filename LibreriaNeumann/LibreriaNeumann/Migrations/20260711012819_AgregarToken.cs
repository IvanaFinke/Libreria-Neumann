using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaNeumann.Migrations
{
    /// <inheritdoc />
    public partial class AgregarToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiracion",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpiracion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenPassword",
                table: "Users");
        }
    }
}
