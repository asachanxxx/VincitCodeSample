using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveObsoletePicklistItemst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [lkp].[PicklistItem] WHERE [TYPE] IN (3, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
