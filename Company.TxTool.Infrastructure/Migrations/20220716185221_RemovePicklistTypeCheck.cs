using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemovePicklistTypeCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem",
                sql: "[Type]='DatabaseType'");
        }
    }
}
