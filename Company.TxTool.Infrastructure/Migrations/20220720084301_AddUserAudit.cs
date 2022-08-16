using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddUserAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AppConfig_User",
                schema: "app",
                table: "AppConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Currency_ModifiedBy",
                schema: "lkp",
                table: "Currency");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyConversion_ModifiedBy",
                schema: "lkp",
                table: "CurrencyConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessage_ModifiedBy",
                schema: "app",
                table: "ErrorMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_ModifiedBy",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_TenantID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ModifiedBy",
                schema: "usr",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationRole_b_Permission_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "app",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "RowModifiedOn",
                schema: "app",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "lkp",
                table: "PicklistType");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "PicklistType");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "lkp",
                table: "Picklist");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "Picklist");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "app",
                table: "ErrorMessage");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "app",
                table: "ErrorMessage");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "lkp",
                table: "CurrencyConversion");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "CurrencyConversion");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "lkp",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "app",
                table: "AppConfig");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "app",
                table: "AppConfig");

            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.RenameColumn(
                name: "ModifiedbyID",
                schema: "app",
                table: "ErrorMessage",
                newName: "ModifiedbyId");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID1",
                schema: "app",
                table: "ErrorMessage",
                newName: "IX_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                schema: "lkp",
                table: "CurrencyConversion",
                newName: "ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID3",
                schema: "lkp",
                table: "CurrencyConversion",
                newName: "IX_CurrencyConversion_ModifiedById");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                schema: "lkp",
                table: "Currency",
                newName: "ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID2",
                schema: "lkp",
                table: "Currency",
                newName: "IX_Currency_ModifiedById");

            migrationBuilder.RenameColumn(
                name: "ModifiedByID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "ModifiedById");

            migrationBuilder.RenameColumn(
                name: "ModifiedbyID",
                schema: "app",
                table: "AppConfig",
                newName: "ModifiedbyId");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID",
                schema: "app",
                table: "AppConfig",
                newName: "IX_AppConfig_ModifiedbyId");

            migrationBuilder.RenameColumn(
                name: "RowModifiedOn",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "RowModified");

            migrationBuilder.RenameIndex(
                name: "UIX_AccountOpenRequest_Type",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_Type");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "User",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "usr",
                table: "User",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                schema: "usr",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                table: "TodoLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TodoLists",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TodoLists",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "TodoLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                table: "TodoLists",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                table: "TodoLists",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                table: "TodoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TodoItems",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TodoItems",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                table: "TodoItems",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                table: "TodoItems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "PicklistItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "PicklistItem",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "lkp",
                table: "PicklistItem",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "Permission",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "Permission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "Permission",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "usr",
                table: "Permission",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                schema: "usr",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "ErrorMessage",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "CurrencyConversion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "Currency",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "ApplicationRole",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "ApplicationRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "ApplicationRole",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "usr",
                table: "ApplicationRole",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                schema: "usr",
                table: "ApplicationRole",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "AppConfig",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAudit",
                schema: "audit",
                columns: table => new
                {
                    UserAuditID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionedByEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActionedByID = table.Column<int>(type: "int", nullable: false),
                    ActionedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DetailsAsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    TenantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAudit", x => x.UserAuditID);
                    table.ForeignKey(
                        name: "FK_UserAudit_ActionedByID",
                        column: x => x.ActionedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAudit_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAudit_UserID",
                        column: x => x.UserID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedByID",
                schema: "usr",
                table: "User",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_CreatedByID",
                table: "TodoLists",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_ModifiedByID",
                table: "TodoLists",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_CreatedByID",
                table: "TodoItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ModifiedByID",
                table: "TodoItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PicklistItem_CreatedByID",
                schema: "lkp",
                table: "PicklistItem",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_CreatedByID",
                schema: "usr",
                table: "Permission",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_CreatedByID",
                schema: "usr",
                table: "ApplicationRole",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_CreatedByID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudit_ActionedByID",
                schema: "audit",
                table: "UserAudit",
                column: "ActionedByID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudit_TenantID",
                schema: "audit",
                table: "UserAudit",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudit_UserID",
                schema: "audit",
                table: "UserAudit",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ReviewedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAccountOpenRequest_CreatedByID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAccountOpenRequest_ModifiedByID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

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
                name: "FK_AppConfig_User_ModifiedbyId",
                schema: "app",
                table: "AppConfig",
                column: "ModifiedbyId",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_CreatedByID",
                schema: "usr",
                table: "ApplicationRole",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_User_ModifiedById",
                schema: "lkp",
                table: "Currency",
                column: "ModifiedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyConversion_User_ModifiedById",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "ModifiedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessage_User_ModifiedbyId",
                schema: "app",
                table: "ErrorMessage",
                column: "ModifiedbyId",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_CreatedByID",
                schema: "usr",
                table: "Permission",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_ModifiedByID",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePicklistItem_CreatedByID",
                schema: "lkp",
                table: "PicklistItem",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasePicklistItem_ModifiedByID",
                schema: "lkp",
                table: "PicklistItem",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

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
                name: "FK_TodoItem_CreatedByID",
                table: "TodoItems",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_ModifiedByID",
                table: "TodoItems",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoList_CreatedByID",
                table: "TodoLists",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoList_ModifiedByID",
                table: "TodoLists",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CreatedByID",
                schema: "usr",
                table: "User",
                column: "CreatedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ModifiedByID",
                schema: "usr",
                table: "User",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAccountOpenRequest_CreatedByID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAccountOpenRequest_ModifiedByID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseAccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AppConfig_User_ModifiedbyId",
                schema: "app",
                table: "AppConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_CreatedByID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Currency_User_ModifiedById",
                schema: "lkp",
                table: "Currency");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyConversion_User_ModifiedById",
                schema: "lkp",
                table: "CurrencyConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessage_User_ModifiedbyId",
                schema: "app",
                table: "ErrorMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_CreatedByID",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedByID",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePicklistItem_CreatedByID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePicklistItem_ModifiedByID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasePicklistItem_TenantID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_CreatedByID",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_ModifiedByID",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoList_CreatedByID",
                table: "TodoLists");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoList_ModifiedByID",
                table: "TodoLists");

            migrationBuilder.DropForeignKey(
                name: "FK_User_CreatedByID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ModifiedByID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserAudit",
                schema: "audit");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedByID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_CreatedByID",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_ModifiedByID",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_CreatedByID",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ModifiedByID",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_PicklistItem_CreatedByID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "IX_Permission_CreatedByID",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationRole_CreatedByID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_CreatedByID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "RowModified",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "RowModified",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "ModifiedbyId",
                schema: "app",
                table: "ErrorMessage",
                newName: "ModifiedbyID");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID",
                schema: "app",
                table: "ErrorMessage",
                newName: "IX_ModifiedByID1");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                schema: "lkp",
                table: "CurrencyConversion",
                newName: "ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_CurrencyConversion_ModifiedById",
                schema: "lkp",
                table: "CurrencyConversion",
                newName: "IX_ModifiedByID3");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                schema: "lkp",
                table: "Currency",
                newName: "ModifiedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Currency_ModifiedById",
                schema: "lkp",
                table: "Currency",
                newName: "IX_ModifiedByID2");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "ModifiedbyId",
                schema: "app",
                table: "AppConfig",
                newName: "ModifiedbyID");

            migrationBuilder.RenameIndex(
                name: "IX_AppConfig_ModifiedbyId",
                schema: "app",
                table: "AppConfig",
                newName: "IX_ModifiedByID");

            migrationBuilder.RenameColumn(
                name: "RowModified",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "RowModifiedOn");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_Type",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "UIX_AccountOpenRequest_Type");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "User",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                table: "TodoLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TodoLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TodoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "app",
                table: "Tenant",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "Tenant",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "Status",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModifiedOn",
                schema: "app",
                table: "Status",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "lkp",
                table: "PicklistType",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "PicklistType",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "PicklistItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "lkp",
                table: "PicklistItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "PicklistItem",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "lkp",
                table: "Picklist",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "Picklist",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "Permission",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "Permission",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "ErrorMessage",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "app",
                table: "ErrorMessage",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "ErrorMessage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "CurrencyConversion",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "lkp",
                table: "CurrencyConversion",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "CurrencyConversion",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "lkp",
                table: "Currency",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "lkp",
                table: "Currency",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "lkp",
                table: "Currency",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "usr",
                table: "ApplicationRole",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "usr",
                table: "ApplicationRole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "usr",
                table: "ApplicationRole",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "AppConfig",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RowModified",
                schema: "app",
                table: "AppConfig",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "AppConfig",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<string>(
                name: "RowModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "(user_name())",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "(user_name())");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedByID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_b_Permission_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ModifiedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ModifiedByID",
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
                name: "FK_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppConfig_User",
                schema: "app",
                table: "AppConfig",
                column: "ModifiedbyID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

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
                name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_ModifiedBy",
                schema: "lkp",
                table: "Currency",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyConversion_ModifiedBy",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessage_ModifiedBy",
                schema: "app",
                table: "ErrorMessage",
                column: "ModifiedbyID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

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
                name: "FK_PicklistItem_ModifiedBy",
                schema: "lkp",
                table: "PicklistItem",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_User_ModifiedBy",
                schema: "usr",
                table: "User",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
