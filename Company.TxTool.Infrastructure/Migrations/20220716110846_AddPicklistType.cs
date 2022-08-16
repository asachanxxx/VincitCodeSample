using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddPicklistType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picklist",
                schema: "lkp",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picklist", x => new { x.Code, x.TenantID });
                });

            migrationBuilder.CreateTable(
                name: "PicklistType",
                schema: "lkp",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicklistType", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picklist",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "PicklistType",
                schema: "lkp");
        }
    }
}
