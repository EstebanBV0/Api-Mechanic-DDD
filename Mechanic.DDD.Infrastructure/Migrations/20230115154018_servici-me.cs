using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mechanic.DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class servicime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
