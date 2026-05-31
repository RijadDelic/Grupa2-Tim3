using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class DodajSlikuPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slikaPath",
                table: "Artikal",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slikaPath",
                table: "Artikal");
        }
    }
}
