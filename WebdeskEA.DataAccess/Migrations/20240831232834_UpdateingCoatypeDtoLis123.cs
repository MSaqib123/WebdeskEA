using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebdeskEA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateingCoatypeDtoLis123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COAType",
                table: "COAType",
                newName: "CoaTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoaTypeName",
                table: "COAType",
                newName: "COAType");
        }
    }
}
