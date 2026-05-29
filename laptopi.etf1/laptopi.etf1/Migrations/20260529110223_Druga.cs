using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class Druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "aktivan",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "datumRegistracije",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "uloga",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aktivan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "datumRegistracije",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "uloga",
                table: "AspNetUsers");
        }
    }
}
