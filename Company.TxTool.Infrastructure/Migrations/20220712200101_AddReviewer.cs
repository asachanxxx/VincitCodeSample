using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddReviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_ModifiedBy",
                schema: "app",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ModifiedBy",
                schema: "usr",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_ModifiedByID4",
                schema: "app",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "app",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                schema: "app",
                table: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID7",
                schema: "usr",
                table: "User",
                newName: "IX_ModifiedByID6");

            migrationBuilder.RenameIndex(
                name: "IX_AdminEmail",
                schema: "app",
                table: "Tenant",
                newName: "UIX_AdminEmail");

            migrationBuilder.RenameColumn(
                name: "StatusCode",
                schema: "app",
                table: "Status",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID6",
                schema: "usr",
                table: "Permission",
                newName: "IX_ModifiedByID5");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID5",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_ModifiedByID4");

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
                oldType: "datetime2",
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
                oldType: "datetime2",
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

            migrationBuilder.AddColumn<int>(
                name: "ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedOn",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "UIX_Code",
                schema: "app",
                table: "Tenant",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ReviewedBy");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest",
                sql: "[Type]='Physical' OR [Type]='Virtual'");

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
                principalColumn: "UserID");

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
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ModifiedBy",
                schema: "usr",
                table: "User");

            migrationBuilder.DropIndex(
                name: "UIX_Code",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "RowModified",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RowModifiedBy",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "ReviewedOn",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID6",
                schema: "usr",
                table: "User",
                newName: "IX_ModifiedByID7");

            migrationBuilder.RenameIndex(
                name: "UIX_AdminEmail",
                schema: "app",
                table: "Tenant",
                newName: "IX_AdminEmail");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "app",
                table: "Status",
                newName: "StatusCode");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID5",
                schema: "usr",
                table: "Permission",
                newName: "IX_ModifiedByID6");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID4",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                newName: "IX_ModifiedByID5");

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
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "Tenant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                schema: "app",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "app",
                table: "Status",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByID",
                schema: "app",
                table: "Status",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID4",
                schema: "app",
                table: "Status",
                column: "ModifiedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ModifiedByID",
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
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_ModifiedBy",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_ModifiedBy",
                schema: "app",
                table: "Status",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ModifiedBy",
                schema: "usr",
                table: "User",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");
        }
    }
}
