using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaIdFk",
                table: "hamburguesa");

            migrationBuilder.DropColumn(
                name: "ChefIdFk",
                table: "hamburguesa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdFk",
                table: "hamburguesa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChefIdFk",
                table: "hamburguesa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
