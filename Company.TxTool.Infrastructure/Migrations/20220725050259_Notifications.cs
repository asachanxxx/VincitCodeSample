using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class Notifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_CopiedFromApplicationRoleID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "app",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnderID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsUnread = table.Column<bool>(type: "bit", nullable: false),
                    TargetEntityId = table.Column<int>(type: "int", nullable: true),
                    TargetEntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notification_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Notification_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Notification_OwnderID",
                        column: x => x.OwnderID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatedByID",
                schema: "app",
                table: "Notification",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ModifiedByID",
                schema: "app",
                table: "Notification",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_OwnderID_IsUnread",
                schema: "app",
                table: "Notification",
                columns: new[] { "OwnderID", "IsUnread" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TenantID",
                schema: "app",
                table: "Notification",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_CopiedFromApplicationRoleID",
                schema: "usr",
                table: "ApplicationRole",
                column: "CopiedFromApplicationRoleID",
                principalSchema: "usr",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_CopiedFromApplicationRoleID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "app");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_CopiedFromApplicationRoleID",
                schema: "usr",
                table: "ApplicationRole",
                column: "CopiedFromApplicationRoleID",
                principalSchema: "usr",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
