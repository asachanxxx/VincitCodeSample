using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class changedPhysicalAccountOpenRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "DatabaseTypeID");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AccountTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_DatabaseTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_AccountTypeID");

            migrationBuilder.AlterColumn<string>(
                name: "ClientRef",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(2,2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_AccountTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                column: "AccountTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                column: "DatabaseTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_AccountTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "DatabaseTypeID",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "DatabaseTypeId");

            migrationBuilder.RenameColumn(
                name: "AccountTypeID",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AccountTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_DatabaseTypeID",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_DatabaseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpenRequest_AccountTypeID",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "IX_AccountOpenRequest_AccountTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientRef",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                column: "AccountTypeId",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                column: "DatabaseTypeId",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
