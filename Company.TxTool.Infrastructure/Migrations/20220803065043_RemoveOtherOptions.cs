using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveOtherOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [lkp].[PicklistItem] WHERE [Code] = 'Other'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
