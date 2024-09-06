using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tayo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageUrlFieldForProductColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductColors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");
        }
    }
}
