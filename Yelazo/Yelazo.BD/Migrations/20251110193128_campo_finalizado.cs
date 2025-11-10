using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yelazo.BD.Migrations
{
    /// <inheritdoc />
    public partial class campo_finalizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Carritos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Carritos");
        }
    }
}
