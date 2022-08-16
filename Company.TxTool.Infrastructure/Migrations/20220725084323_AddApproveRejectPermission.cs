using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddApproveRejectPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [usr].[ApplicationRole_b_Permission] WHERE [PermissionID] IN (SELECT [PermissionID] FROM [usr].[Permission] WHERE [PermissionCode] IN ('AorReject', 'AorComplete', 'ReconReject', 'ReconApprove', 'AcrReject', 'AcrApprove', 'AcrComplete'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
