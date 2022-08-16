using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.CreateIndex(
                name: "IX_Picklist_TenantID",
                schema: "lkp",
                table: "Picklist",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ApplicationRoleID",
                principalSchema: "usr",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "PermissionID",
                principalSchema: "usr",
                principalTable: "Permission",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Picklist_TenantID",
                schema: "lkp",
                table: "Picklist",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Picklist_TenantID",
                schema: "lkp",
                table: "Picklist");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_Picklist_TenantID",
                schema: "lkp",
                table: "Picklist");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ApplicationRoleID",
                principalSchema: "usr",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "PermissionID",
                principalSchema: "usr",
                principalTable: "Permission",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
