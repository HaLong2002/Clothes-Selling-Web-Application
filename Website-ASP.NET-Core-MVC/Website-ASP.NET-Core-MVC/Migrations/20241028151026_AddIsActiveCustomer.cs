using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_ASP.NET_Core_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Customers");
        }
    }
}
