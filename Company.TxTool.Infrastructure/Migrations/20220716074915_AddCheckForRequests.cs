using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddCheckForRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest",
                sql: "[Type]='Physical' OR [Type]='Virtual'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest");
        }
    }
}
