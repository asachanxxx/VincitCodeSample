using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class ReconciliationBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequestType_TenantID",
                schema: "lkp",
                table: "AccountOpenRequestType");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePicklistItem_TenantID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistType_TenantID",
                schema: "lkp",
                table: "PicklistType");

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

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AccountRegister",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRegister_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_AccountRegister_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_AccountRegister_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reconciliation",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountRegisterId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OriginFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreparedById = table.Column<int>(type: "int", nullable: false),
                    ReviewedById = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Reconciliation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reconciliation_AccountRegister_AccountRegisterId",
                        column: x => x.AccountRegisterId,
                        principalSchema: "app",
                        principalTable: "AccountRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reconciliation_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Reconciliation_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Reconciliation_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reconciliation_User_PreparedById",
                        column: x => x.PreparedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reconciliation_User_ReviewedById",
                        column: x => x.ReviewedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReconciliationSchedule",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    AccountRegisterId = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TriggerBeforeEventInHours = table.Column<int>(type: "int", nullable: false),
                    DeadlineAfterEventInDays = table.Column<byte>(type: "tinyint", nullable: false),
                    PreparedById = table.Column<int>(type: "int", nullable: false),
                    ReviewedById = table.Column<int>(type: "int", nullable: false),
                    NextReconciliationToBeCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconciliationSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_AccountRegister_AccountRegisterId",
                        column: x => x.AccountRegisterId,
                        principalSchema: "app",
                        principalTable: "AccountRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_User_PreparedById",
                        column: x => x.PreparedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReconciliationSchedule_User_ReviewedById",
                        column: x => x.ReviewedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_CreatedByID",
                schema: "app",
                table: "AccountRegister",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_ModifiedByID",
                schema: "app",
                table: "AccountRegister",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_TenantID",
                schema: "app",
                table: "AccountRegister",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_AccountRegisterId",
                schema: "app",
                table: "Reconciliation",
                column: "AccountRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_CreatedByID",
                schema: "app",
                table: "Reconciliation",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_ModifiedByID",
                schema: "app",
                table: "Reconciliation",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_PreparedById",
                schema: "app",
                table: "Reconciliation",
                column: "PreparedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_ReviewedById",
                schema: "app",
                table: "Reconciliation",
                column: "ReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliation_TenantID",
                schema: "app",
                table: "Reconciliation",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_AccountRegisterId",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "AccountRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_CreatedByID",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_ModifiedByID",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_PreparedById",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "PreparedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_ReviewedById",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "ReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_TenantID",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" });

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistItem_TenantID_Type",
                schema: "lkp",
                table: "PicklistItem",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "PicklistType",
                principalColumns: new[] { "TenantID", "Value" });
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
                name: "Reconciliation",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ReconciliationSchedule",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AccountRegister",
                schema: "app");

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
                name: "FK_AccountOpenRequest_TenantID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequestType_TenantID",
                schema: "lkp",
                table: "AccountOpenRequestType",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasePicklistItem_TenantID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistType_TenantID",
                schema: "lkp",
                table: "PicklistType",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
