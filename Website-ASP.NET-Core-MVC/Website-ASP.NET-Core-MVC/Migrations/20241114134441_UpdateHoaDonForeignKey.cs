using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_ASP.NET_Core_MVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHoaDonForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_AspNetUsers_UserId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_UserId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HoaDon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_UserId",
                table: "HoaDon",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_AspNetUsers_UserId",
                table: "HoaDon",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
