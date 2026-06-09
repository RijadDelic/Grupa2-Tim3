using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class DodajCijenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "cijena",
                table: "Artikal",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SlikaArtikla_artikalId",
                table: "SlikaArtikla",
                column: "artikalId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikaArtikla_Artikal_artikalId",
                table: "SlikaArtikla",
                column: "artikalId",
                principalTable: "Artikal",
                principalColumn: "ArtikalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikaArtikla_Artikal_artikalId",
                table: "SlikaArtikla");

            migrationBuilder.DropIndex(
                name: "IX_SlikaArtikla_artikalId",
                table: "SlikaArtikla");

            migrationBuilder.DropColumn(
                name: "cijena",
                table: "Artikal");
        }
    }
}
