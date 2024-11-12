using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_ASP.NET_Core_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucMaDM",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_DanhMucMaDM",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "DanhMucMaDM",
                table: "SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaDM",
                table: "SanPham",
                column: "MaDM");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_DanhMuc_MaDM",
                table: "SanPham",
                column: "MaDM",
                principalTable: "DanhMuc",
                principalColumn: "MaDM",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_DanhMuc_MaDM",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaDM",
                table: "SanPham");

            migrationBuilder.AddColumn<int>(
                name: "DanhMucMaDM",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_DanhMucMaDM",
                table: "SanPham",
                column: "DanhMucMaDM");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_DanhMuc_DanhMucMaDM",
                table: "SanPham",
                column: "DanhMucMaDM",
                principalTable: "DanhMuc",
                principalColumn: "MaDM",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
