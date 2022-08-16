using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class DeleteGDPUsage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [app].[AccountOpenRequest] WHERE [CurrencyID] = (SELECT [Id] FROM [lkp].[PicklistItem] WHERE [Name] = 'GDP')");
            migrationBuilder.Sql("DELETE FROM [lkp].[PicklistItem] WHERE [Name] = 'GDP'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
