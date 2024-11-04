using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initialsignup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "signup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "signup");

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
