using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class DisablePicklistItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [lkp].[PicklistItem] SET [IsActive] = 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
