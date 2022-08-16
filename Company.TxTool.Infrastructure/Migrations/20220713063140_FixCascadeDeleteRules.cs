using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class FixCascadeDeleteRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_RequestedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID6",
                schema: "usr",
                table: "User",
                newName: "IX_User_ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID5",
                schema: "usr",
                table: "Permission",
                newName: "IX_Permission_ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_ApplicationRole_b_Permission_PermissionID");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID4",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_ApplicationRole_b_Permission_ModifiedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_RequestedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "RequestedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ReviewedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "StatusID",
                principalSchema: "app",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_RequestedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User");

            migrationBuilder.RenameIndex(
                name: "IX_User_ModifiedByID",
                schema: "usr",
                table: "User",
                newName: "IX_ModifiedByID6");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_ModifiedByID",
                schema: "usr",
                table: "Permission",
                newName: "IX_ModifiedByID5");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRole_b_Permission_PermissionID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_PermissionID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRole_b_Permission_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_ModifiedByID4");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_RequestedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "RequestedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ReviewedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "StatusID",
                principalSchema: "app",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ApplicationRoleID",
                principalSchema: "usr",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_b_Permission_Permission",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "PermissionID",
                principalSchema: "usr",
                principalTable: "Permission",
                principalColumn: "PermissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
