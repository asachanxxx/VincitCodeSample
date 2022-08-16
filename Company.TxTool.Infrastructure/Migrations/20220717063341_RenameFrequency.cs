using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RenameFrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReonciliationFrequncy",
                schema: "lkp",
                table: "PicklistItem",
                newName: "ReconciliationFrequency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReconciliationFrequency",
                schema: "lkp",
                table: "PicklistItem",
                newName: "ReonciliationFrequncy");
        }
    }
}
