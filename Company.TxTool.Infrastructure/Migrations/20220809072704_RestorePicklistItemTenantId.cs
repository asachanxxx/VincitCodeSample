using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RestorePicklistItemTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "UIX_PicklistItem_TenantID_Type_Code",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "UIX_PicklistItem_TenantID_Type_Name",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UIX_PicklistItem_TenantID_Type_Code",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_PicklistItem_TenantID_Type_Name",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistItem_TenantID",
                schema: "lkp",
                table: "PicklistItem",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "PicklistType",
                principalColumns: new[] { "TenantID", "Value" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "UIX_PicklistItem_TenantID_Type_Code",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "UIX_PicklistItem_TenantID_Type_Name",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "UIX_PicklistItem_TenantID_Type_Code",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type", "Code" },
                unique: true,
                filter: "[TenantID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UIX_PicklistItem_TenantID_Type_Name",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type", "Name" },
                unique: true,
                filter: "[TenantID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "PicklistType",
                principalColumns: new[] { "TenantID", "Value" });
        }
    }
}
