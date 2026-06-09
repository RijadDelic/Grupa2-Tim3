using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class DodajTipTransakcije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipTransakcije",
                table: "Artikal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipTransakcije",
                table: "Artikal");
        }
    }
}
