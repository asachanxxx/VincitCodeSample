using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class MakeColumnsNulluble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_AccountTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_AccountTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                column: "AccountTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID_Type",
                schema: "app",
                table: "AccountOpenRequest",
                column: "DatabaseTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");
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
    }
}