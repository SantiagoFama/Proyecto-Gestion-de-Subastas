using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSubasta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subastadores",
                columns: table => new
                {
                    dni = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastadores", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "Postores",
                columns: table => new
                {
                    dni = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Subastaid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postores", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecioInicial = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioPuja = table.Column<decimal>(type: "TEXT", nullable: false),
                    Duracion = table.Column<decimal>(type: "TEXT", nullable: false),
                    Pujas = table.Column<int>(type: "INTEGER", nullable: false),
                    Articulo = table.Column<string>(type: "TEXT", nullable: false),
                    Subastadordni = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ganadordni = table.Column<int>(type: "INTEGER", nullable: true),
                    Finalizada = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subastas_Postores_Ganadordni",
                        column: x => x.Ganadordni,
                        principalTable: "Postores",
                        principalColumn: "dni");
                    table.ForeignKey(
                        name: "FK_Subastas_Subastadores_Subastadordni",
                        column: x => x.Subastadordni,
                        principalTable: "Subastadores",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postores_Subastaid",
                table: "Postores",
                column: "Subastaid");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_Ganadordni",
                table: "Subastas",
                column: "Ganadordni");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_Subastadordni",
                table: "Subastas",
                column: "Subastadordni");

            migrationBuilder.AddForeignKey(
                name: "FK_Postores_Subastas_Subastaid",
                table: "Postores",
                column: "Subastaid",
                principalTable: "Subastas",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postores_Subastas_Subastaid",
                table: "Postores");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Postores");

            migrationBuilder.DropTable(
                name: "Subastadores");
        }
    }
}
