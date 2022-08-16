using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveEnumConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [lkp].[PicklistItem]");

            migrationBuilder.DropTable(
                name: "Picklist",
                schema: "lkp");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "AccountOpenRequestType",
                schema: "lkp",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpenRequestType", x => new { x.TenantID, x.Value });
                    table.ForeignKey(
                        name: "FK_AccountOpenRequestType_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PicklistType",
                schema: "lkp",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicklistType", x => new { x.TenantID, x.Value });
                    table.ForeignKey(
                        name: "FK_PicklistType_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" },
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
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropTable(
                name: "AccountOpenRequestType",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "PicklistType",
                schema: "lkp");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "lkp",
                table: "PicklistItem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "tinyint",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Picklist",
                schema: "lkp",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picklist", x => new { x.Code, x.TenantID });
                    table.ForeignKey(
                        name: "FK_Picklist_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Picklist_TenantID",
                schema: "lkp",
                table: "Picklist",
                column: "TenantID");
        }
    }
}
