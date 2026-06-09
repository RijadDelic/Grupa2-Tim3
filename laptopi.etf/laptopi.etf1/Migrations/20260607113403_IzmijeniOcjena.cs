using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class IzmijeniOcjena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "artikalId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "Ocjena");

            migrationBuilder.AddColumn<string>(
                name: "ocjenjenId",
                table: "Ocjena",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ocjenjivacId",
                table: "Ocjena",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ocjenjenId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "ocjenjivacId",
                table: "Ocjena");

            migrationBuilder.AddColumn<int>(
                name: "artikalId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "korisnikId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
