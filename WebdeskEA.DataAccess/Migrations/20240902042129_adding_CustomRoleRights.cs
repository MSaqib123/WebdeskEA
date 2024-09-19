using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebdeskEA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adding_CustomRoleRights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsModule = table.Column<bool>(type: "bit", nullable: false),
                    IsSubModule = table.Column<bool>(type: "bit", nullable: false),
                    IsForm = table.Column<bool>(type: "bit", nullable: false),
                    SubForm = table.Column<bool>(type: "bit", nullable: false),
                    ParentModuleId = table.Column<int>(type: "int", nullable: true),
                    ModuleUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ModulePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsTab = table.Column<bool>(type: "bit", nullable: false),
                    ModuleIcon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsExpand = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightInsert = table.Column<bool>(type: "bit", nullable: false),
                    RightUpdate = table.Column<bool>(type: "bit", nullable: false),
                    RightView = table.Column<bool>(type: "bit", nullable: false),
                    RightPrint = table.Column<bool>(type: "bit", nullable: false),
                    RightDelete = table.Column<bool>(type: "bit", nullable: false),
                    RightEdit = table.Column<bool>(type: "bit", nullable: false),
                    RightApprove = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "UserRights");
        }
    }
}
