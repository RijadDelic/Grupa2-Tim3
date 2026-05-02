using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrvaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminModerator",
                columns: table => new
                {
                    adminModeratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uloga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModerator", x => x.adminModeratorId);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ArtikalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stranje = table.Column<int>(type: "int", nullable: false),
                    datumObjave = table.Column<DateOnly>(type: "date", nullable: false),
                    aktivnost = table.Column<bool>(type: "bit", nullable: false),
                    prosjecnaOcjena = table.Column<double>(type: "float", nullable: false),
                    kategorija = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ArtikalId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uloga = table.Column<int>(type: "int", nullable: false),
                    datumRegistracije = table.Column<DateOnly>(type: "date", nullable: false),
                    akrivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    ojcenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<int>(type: "int", nullable: false),
                    datumOcjenjivanja = table.Column<DateOnly>(type: "date", nullable: false),
                    artikalId = table.Column<int>(type: "int", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.ojcenaId);
                });

            migrationBuilder.CreateTable(
                name: "Primjedba",
                columns: table => new
                {
                    primjedbaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumPrimjedbe = table.Column<DateOnly>(type: "date", nullable: false),
                    validnost = table.Column<bool>(type: "bit", nullable: false),
                    artikalId = table.Column<int>(type: "int", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primjedba", x => x.primjedbaId);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    rezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumOd = table.Column<DateOnly>(type: "date", nullable: false),
                    datumDo = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    datumZahtjeva = table.Column<DateOnly>(type: "date", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.rezervacijaId);
                });

            migrationBuilder.CreateTable(
                name: "SlikaArtikla",
                columns: table => new
                {
                    slikaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    putanjaDatoteke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artikalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikaArtikla", x => x.slikaId);
                });

            migrationBuilder.CreateTable(
                name: "Tranakcija",
                columns: table => new
                {
                    transakcijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artikalId = table.Column<int>(type: "int", nullable: false),
                    kupacId = table.Column<int>(type: "int", nullable: false),
                    prodavacId = table.Column<int>(type: "int", nullable: false),
                    tipTransakcije = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateOnly>(type: "date", nullable: false),
                    iznos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tranakcija", x => x.transakcijaId);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevZaUklanjanje",
                columns: table => new
                {
                    zahtjevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razlog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumZahtjeva = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    artikalId = table.Column<int>(type: "int", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    adminModeratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaUklanjanje", x => x.zahtjevId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminModerator");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Primjedba");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "SlikaArtikla");

            migrationBuilder.DropTable(
                name: "Tranakcija");

            migrationBuilder.DropTable(
                name: "ZahtjevZaUklanjanje");
        }
    }
}
