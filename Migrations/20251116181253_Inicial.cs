using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSubasta.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postores",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postores", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Subastadores",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastadores", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecioInicial = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioPuja = table.Column<decimal>(type: "TEXT", nullable: false),
                    Duracion = table.Column<decimal>(type: "TEXT", nullable: false),
                    Pujas = table.Column<int>(type: "INTEGER", nullable: false),
                    Articulo = table.Column<string>(type: "TEXT", nullable: false),
                    SubastadorDni = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GanadorDni = table.Column<int>(type: "INTEGER", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subastas_Postores_GanadorDni",
                        column: x => x.GanadorDni,
                        principalTable: "Postores",
                        principalColumn: "Dni");
                    table.ForeignKey(
                        name: "FK_Subastas_Subastadores_SubastadorDni",
                        column: x => x.SubastadorDni,
                        principalTable: "Subastadores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostorSubasta",
                columns: table => new
                {
                    PostoresDni = table.Column<int>(type: "INTEGER", nullable: false),
                    SubastasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostorSubasta", x => new { x.PostoresDni, x.SubastasId });
                    table.ForeignKey(
                        name: "FK_PostorSubasta_Postores_PostoresDni",
                        column: x => x.PostoresDni,
                        principalTable: "Postores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostorSubasta_Subastas_SubastasId",
                        column: x => x.SubastasId,
                        principalTable: "Subastas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostorSubasta_SubastasId",
                table: "PostorSubasta",
                column: "SubastasId");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_GanadorDni",
                table: "Subastas",
                column: "GanadorDni");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_SubastadorDni",
                table: "Subastas",
                column: "SubastadorDni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostorSubasta");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Postores");

            migrationBuilder.DropTable(
                name: "Subastadores");
        }
    }
}
