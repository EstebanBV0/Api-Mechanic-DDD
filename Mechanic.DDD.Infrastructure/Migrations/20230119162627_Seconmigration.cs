using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mechanic.DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seconmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mecanicos_Servicios_ServicioForeiId",
                table: "Mecanicos");

            migrationBuilder.DropIndex(
                name: "IX_Mecanicos_ServicioForeiId",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "ServicioForeiId",
                table: "Mecanicos");

            migrationBuilder.AddColumn<int>(
                name: "MecanicoId",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_MecanicoId",
                table: "Servicios",
                column: "MecanicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Mecanicos_MecanicoId",
                table: "Servicios",
                column: "MecanicoId",
                principalTable: "Mecanicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Mecanicos_MecanicoId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_MecanicoId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "MecanicoId",
                table: "Servicios");

            migrationBuilder.AddColumn<int>(
                name: "ServicioForeiId",
                table: "Mecanicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mecanicos_ServicioForeiId",
                table: "Mecanicos",
                column: "ServicioForeiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mecanicos_Servicios_ServicioForeiId",
                table: "Mecanicos",
                column: "ServicioForeiId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
