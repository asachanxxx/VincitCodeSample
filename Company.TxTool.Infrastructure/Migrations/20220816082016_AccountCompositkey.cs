using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AccountCompositkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_TenantID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "app",
                table: "AccountRegister",
                newName: "AccountRegisterID");

            migrationBuilder.AddColumn<string>(
                name: "AccountGroup",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountGroupUpdatedOn",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "app",
                table: "AccountRegister",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountRegister",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountName",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankID",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankRe1",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankRe2",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChartCode",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientRef",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatabaseTypeID",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAmountOfOpeningBalanceMovedIntoAccount",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOpened",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegisterEntryCompleted",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSetupOnDatabase",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositLetterLastLetterSent",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepositLetterTenantRef",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpenseCode",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                schema: "app",
                table: "AccountRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewId())");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayingInBooksToGoTo",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalBankAdminSortCode",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostingRulesInBMAPDebtorClientRef",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrefferedCashbookID",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyNumber",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReconciliationFrequency",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestedBy",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedOn",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewedBy",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedOn",
                schema: "app",
                table: "AccountRegister",
                type: "datetime2(2)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScheduleRef",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortCode",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "app",
                table: "AccountRegister",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "TenancyReferenceNumber",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrampsCashbookId",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionTypeCode",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VirtualAccountNumber",
                schema: "app",
                table: "AccountRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountRegister_b_Document",
                schema: "app",
                columns: table => new
                {
                    SupportDocumentID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    DocumentType = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountRegisterId = table.Column<int>(type: "int", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRegister_b_Document", x => x.SupportDocumentID);
                    table.ForeignKey(
                        name: "FK_AccountRegister_b_Document_AccountRegister_AccountRegisterId",
                        column: x => x.AccountRegisterId,
                        principalSchema: "app",
                        principalTable: "AccountRegister",
                        principalColumn: "AccountRegisterID");
                    table.ForeignKey(
                        name: "FK_AccountRegister_b_Document_SupportDocumentID",
                        column: x => x.SupportDocumentID,
                        principalSchema: "app",
                        principalTable: "SupportDocument",
                        principalColumn: "SupportDocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountRegisterBDocumentation_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_AccountTypeID",
                schema: "app",
                table: "AccountRegister",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister",
                column: "BankReconciliationsToBePreparedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister",
                column: "BankReconciliationsToBeReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_CurrencyID",
                schema: "app",
                table: "AccountRegister",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_DatabaseTypeID",
                schema: "app",
                table: "AccountRegister",
                column: "DatabaseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_RequestedBy",
                schema: "app",
                table: "AccountRegister",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_ReviewedBy",
                schema: "app",
                table: "AccountRegister",
                column: "ReviewedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_Status",
                schema: "app",
                table: "AccountRegister",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_TenantID_Type",
                schema: "app",
                table: "AccountRegister",
                columns: new[] { "TenantID", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_Type",
                schema: "app",
                table: "AccountRegister",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "UIX_AccountRegister_Guid",
                schema: "app",
                table: "AccountRegister",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_b_Document_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "AccountRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_b_Document_TenantID",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_AccountTypeID",
                schema: "app",
                table: "AccountRegister",
                column: "AccountTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister",
                column: "BankReconciliationsToBePreparedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister",
                column: "BankReconciliationsToBeReviewedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_CurrencyID",
                schema: "app",
                table: "AccountRegister",
                column: "CurrencyID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_DatabaseTypeID",
                schema: "app",
                table: "AccountRegister",
                column: "DatabaseTypeID",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_RequestedBy",
                schema: "app",
                table: "AccountRegister",
                column: "RequestedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_ReviewedBy",
                schema: "app",
                table: "AccountRegister",
                column: "ReviewedBy",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_TenantID_Type",
                schema: "app",
                table: "AccountRegister",
                columns: new[] { "TenantID", "Type" },
                principalSchema: "lkp",
                principalTable: "AccountOpenRequestType",
                principalColumns: new[] { "TenantID", "Value" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_AccountTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_CurrencyID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_DatabaseTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_RequestedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_ReviewedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_TenantID_Type",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropTable(
                name: "AccountRegister_b_Document",
                schema: "app");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_AccountTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_CurrencyID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_DatabaseTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_RequestedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_ReviewedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_Status",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_TenantID_Type",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_Type",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropIndex(
                name: "UIX_AccountRegister_Guid",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AccountGroup",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AccountGroupUpdatedOn",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankAccountName",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankRe1",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankRe2",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ChartCode",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ClientName",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ClientRef",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DatabaseTypeID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DateAmountOfOpeningBalanceMovedIntoAccount",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DateOpened",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DateReceived",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DateRegisterEntryCompleted",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DateSetupOnDatabase",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DepositLetterLastLetterSent",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "DepositLetterTenantRef",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ExpenseCode",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "Guid",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PayingInBooksToGoTo",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PhysicalBankAdminSortCode",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PostingRulesInBMAPDebtorClientRef",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PrefferedCashbookID",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "PropertyNumber",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ReconciliationFrequency",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "RequestedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "RequestedOn",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ReviewedOn",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ScheduleRef",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "SortCode",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "TenancyReferenceNumber",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "TenantName",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "TrampsCashbookId",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "TransactionTypeCode",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "VirtualAccountNumber",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.RenameColumn(
                name: "AccountRegisterID",
                schema: "app",
                table: "AccountRegister",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_TenantID",
                schema: "app",
                table: "AccountRegister",
                column: "TenantID");
        }
    }
}
