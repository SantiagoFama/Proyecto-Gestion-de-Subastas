using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSubasta.Migrations
{
    /// <inheritdoc />
    public partial class DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subastas_Postores_Ganadordni",
                table: "Subastas");

            migrationBuilder.DropForeignKey(
                name: "FK_Subastas_Subastadores_Subastadordni",
                table: "Subastas");

            migrationBuilder.RenameColumn(
                name: "Subastadordni",
                table: "Subastas",
                newName: "SubastadorDni");

            migrationBuilder.RenameColumn(
                name: "Ganadordni",
                table: "Subastas",
                newName: "GanadorDni");

            migrationBuilder.RenameIndex(
                name: "IX_Subastas_Subastadordni",
                table: "Subastas",
                newName: "IX_Subastas_SubastadorDni");

            migrationBuilder.RenameIndex(
                name: "IX_Subastas_Ganadordni",
                table: "Subastas",
                newName: "IX_Subastas_GanadorDni");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Subastadores",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Postores",
                newName: "Dni");

            migrationBuilder.AddForeignKey(
                name: "FK_Subastas_Postores_GanadorDni",
                table: "Subastas",
                column: "GanadorDni",
                principalTable: "Postores",
                principalColumn: "Dni");

            migrationBuilder.AddForeignKey(
                name: "FK_Subastas_Subastadores_SubastadorDni",
                table: "Subastas",
                column: "SubastadorDni",
                principalTable: "Subastadores",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subastas_Postores_GanadorDni",
                table: "Subastas");

            migrationBuilder.DropForeignKey(
                name: "FK_Subastas_Subastadores_SubastadorDni",
                table: "Subastas");

            migrationBuilder.RenameColumn(
                name: "SubastadorDni",
                table: "Subastas",
                newName: "Subastadordni");

            migrationBuilder.RenameColumn(
                name: "GanadorDni",
                table: "Subastas",
                newName: "Ganadordni");

            migrationBuilder.RenameIndex(
                name: "IX_Subastas_SubastadorDni",
                table: "Subastas",
                newName: "IX_Subastas_Subastadordni");

            migrationBuilder.RenameIndex(
                name: "IX_Subastas_GanadorDni",
                table: "Subastas",
                newName: "IX_Subastas_Ganadordni");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Subastadores",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Postores",
                newName: "dni");

            migrationBuilder.AddForeignKey(
                name: "FK_Subastas_Postores_Ganadordni",
                table: "Subastas",
                column: "Ganadordni",
                principalTable: "Postores",
                principalColumn: "dni");

            migrationBuilder.AddForeignKey(
                name: "FK_Subastas_Subastadores_Subastadordni",
                table: "Subastas",
                column: "Subastadordni",
                principalTable: "Subastadores",
                principalColumn: "dni",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
