using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mechanic.DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class onemigraton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Dueños_DueñoId",
                table: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "DueñoId",
                table: "Vehiculos",
                newName: "DuenoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculos_DueñoId",
                table: "Vehiculos",
                newName: "IX_Vehiculos_DuenoId");

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Mecanicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Dueños",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Dueños_DuenoId",
                table: "Vehiculos",
                column: "DuenoId",
                principalTable: "Dueños",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Dueños_DuenoId",
                table: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "DuenoId",
                table: "Vehiculos",
                newName: "DueñoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculos_DuenoId",
                table: "Vehiculos",
                newName: "IX_Vehiculos_DueñoId");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Dueños",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Dueños_DueñoId",
                table: "Vehiculos",
                column: "DueñoId",
                principalTable: "Dueños",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
