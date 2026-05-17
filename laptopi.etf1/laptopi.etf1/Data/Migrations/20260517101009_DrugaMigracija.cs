using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrugaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ojcenaId",
                table: "Ocjena",
                newName: "ocjenaId");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Korisnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Korisnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Korisnik",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Korisnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Korisnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AdminModerator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AdminModerator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AdminModerator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AdminModerator",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AdminModerator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AdminModerator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AdminModerator",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AdminModerator");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AdminModerator");

            migrationBuilder.RenameColumn(
                name: "ocjenaId",
                table: "Ocjena",
                newName: "ojcenaId");
        }
    }
}
