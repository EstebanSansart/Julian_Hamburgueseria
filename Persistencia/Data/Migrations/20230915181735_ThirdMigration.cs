using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hamburguesa_categoria_CategoriaId",
                table: "hamburguesa");

            migrationBuilder.DropForeignKey(
                name: "FK_hamburguesa_chef_ChefId",
                table: "hamburguesa");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "hamburguesa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "hamburguesa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_hamburguesa_categoria_CategoriaId",
                table: "hamburguesa",
                column: "CategoriaId",
                principalTable: "categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hamburguesa_chef_ChefId",
                table: "hamburguesa",
                column: "ChefId",
                principalTable: "chef",
                principalColumn: "IdChef",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hamburguesa_categoria_CategoriaId",
                table: "hamburguesa");

            migrationBuilder.DropForeignKey(
                name: "FK_hamburguesa_chef_ChefId",
                table: "hamburguesa");

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "hamburguesa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "hamburguesa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_hamburguesa_categoria_CategoriaId",
                table: "hamburguesa",
                column: "CategoriaId",
                principalTable: "categoria",
                principalColumn: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_hamburguesa_chef_ChefId",
                table: "hamburguesa",
                column: "ChefId",
                principalTable: "chef",
                principalColumn: "IdChef");
        }
    }
}
