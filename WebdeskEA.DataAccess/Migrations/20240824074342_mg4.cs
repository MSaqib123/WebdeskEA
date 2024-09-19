using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebdeskEA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErrorLogDescription",
                table: "ErrorLogs",
                newName: "ErrorLogShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "ErrorFrom",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ErrorLogLongDescription",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorFrom",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "ErrorLogLongDescription",
                table: "ErrorLogs");

            migrationBuilder.RenameColumn(
                name: "ErrorLogShortDescription",
                table: "ErrorLogs",
                newName: "ErrorLogDescription");
        }
    }
}
