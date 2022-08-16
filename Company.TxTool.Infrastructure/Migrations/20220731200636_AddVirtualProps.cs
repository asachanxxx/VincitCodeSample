using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddVirtualProps : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest",
                column: "BankReconciliationsToBePreparedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest",
                column: "BankReconciliationsToBeReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_CurrencyID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_AccountTypeID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "AccountTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest",
                column: "BankReconciliationsToBePreparedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest",
                column: "BankReconciliationsToBeReviewedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_CurrencyID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "CurrencyID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID",
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
                name: "FK_AccountOpenRequest_AccountTypeID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_CurrencyID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_DatabaseTypeID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_CurrencyID",
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
    }
}
