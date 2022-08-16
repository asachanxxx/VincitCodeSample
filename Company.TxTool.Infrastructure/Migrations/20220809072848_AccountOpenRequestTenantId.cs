using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AccountOpenRequestTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" });
        }
    }
}
