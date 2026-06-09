using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class DodajZauzetDatum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZauzetDatum",
                columns: table => new
                {
                    zauzetDatumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artikalId = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZauzetDatum", x => x.zauzetDatumId);
                    table.ForeignKey(
                        name: "FK_ZauzetDatum_Artikal_artikalId",
                        column: x => x.artikalId,
                        principalTable: "Artikal",
                        principalColumn: "ArtikalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZauzetDatum_artikalId",
                table: "ZauzetDatum",
                column: "artikalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZauzetDatum");
        }
    }
}
