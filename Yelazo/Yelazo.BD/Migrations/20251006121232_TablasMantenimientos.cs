using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yelazo.BD.Migrations
{
    /// <inheritdoc />
    public partial class TablasMantenimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActividadMantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaActividad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    MantenimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadMantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadMantenimientos_Mantenimientos_MantenimientoId",
                        column: x => x.MantenimientoId,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadMantenimientos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleActividadMantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    ActividadMantenimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleActividadMantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleActividadMantenimientos_ActividadMantenimientos_ActividadMantenimientoId",
                        column: x => x.ActividadMantenimientoId,
                        principalTable: "ActividadMantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleActividadMantenimientos_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadMantenimientos_MantenimientoId",
                table: "ActividadMantenimientos",
                column: "MantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadMantenimientos_ProveedorId",
                table: "ActividadMantenimientos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleActividadMantenimientos_ActividadMantenimientoId",
                table: "DetalleActividadMantenimientos",
                column: "ActividadMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleActividadMantenimientos_InsumoId",
                table: "DetalleActividadMantenimientos",
                column: "InsumoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleActividadMantenimientos");

            migrationBuilder.DropTable(
                name: "ActividadMantenimientos");
        }
    }
}
