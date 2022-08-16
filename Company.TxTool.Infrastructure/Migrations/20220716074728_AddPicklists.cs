using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddPicklists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_ModifiedByID");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PicklistItem",
                schema: "lkp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false),
                    ModifiedByID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicklistItem", x => x.Id);
                    table.CheckConstraint("CK_PicklistItem_Type", "[Type]='DatabaseType'");
                    table.ForeignKey(
                        name: "FK_PicklistItem_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PicklistItem_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UIX_AccountOpenRequest_Type",
                schema: "app",
                table: "AccountOpenRequest",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_PicklistItem_ModifiedByID",
                schema: "lkp",
                table: "PicklistItem",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "UIX_PicklistItem_TenantID_Type_Name",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PicklistItem",
                schema: "lkp");

            migrationBuilder.DropIndex(
                name: "UIX_AccountOpenRequest_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_ModifiedByID",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_ModifiedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest",
                sql: "[Type]='Physical' OR [Type]='Virtual'");
        }
    }
}
