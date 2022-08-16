using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class UpdateCodeWithName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [lkp].[PicklistItem] SET [Code] = [Name]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
