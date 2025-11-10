using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yelazo.BD.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c2660628308e', 'admin', 'ADMIN')");

            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c2660628419f', 'produccion', 'PRODUCCION')");

            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c3770628308e', 'repartidor', 'REPARTIDOR')");

            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('ba018153-7544-4fbd-a59c-c5880628532e', 'cliente', 'CLIENTE')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = 'ba018153-7544-4fbd-a59c-c2660628308e'");
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = 'ba018153-7544-4fbd-a59c-c2660628419f'");
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = 'ba018153-7544-4fbd-a59c-c3770628308e'");
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = 'ba018153-7544-4fbd-a59c-c5880628532e'");
        }
    }
}
