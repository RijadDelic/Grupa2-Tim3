using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laptopi.etf1.Migrations
{
    /// <inheritdoc />
    public partial class SortiranjeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Artikal",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_UserId",
                table: "Artikal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikal_AspNetUsers_UserId",
                table: "Artikal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikal_AspNetUsers_UserId",
                table: "Artikal");

            migrationBuilder.DropIndex(
                name: "IX_Artikal_UserId",
                table: "Artikal");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Artikal",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
