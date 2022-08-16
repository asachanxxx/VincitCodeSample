using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class completeAccountOpenRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankNameRe2",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankRe1",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankRe2",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankSortCode",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BibSet",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BibSetupdatedOn",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientRef",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAmountOfOpeningBalanceMovedIntoAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOpened",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegisterEntryCompleted",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSetupOnTramps",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositLetterLastLetterSent",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepositLetterTenantRef",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningBalance",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayingInBooksToGoTo",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrefferedCashbookID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reconciliations",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDate",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortCode",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatementsAndReconciliations",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenancyReferenceNumber",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrampsCashbookId",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupportDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documentTypeId = table.Column<int>(type: "int", nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportDocument_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_SupportDocument_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_SupportDocument_PicklistItem_documentTypeId",
                        column: x => x.documentTypeId,
                        principalSchema: "lkp",
                        principalTable: "PicklistItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest",
                column: "DatabaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_CreatedByID",
                table: "SupportDocument",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_documentTypeId",
                table: "SupportDocument",
                column: "documentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_ModifiedByID",
                table: "SupportDocument",
                column: "ModifiedByID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_PicklistItem_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropTable(
                name: "SupportDocument");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankNameRe2",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankRe1",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankRe2",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankReconciliationsToBePreparedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankReconciliationsToBeReviewedById",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankSortCode",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BibSet",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BibSetupdatedOn",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "ClientRef",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DatabaseTypeId",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DateAmountOfOpeningBalanceMovedIntoAccount",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DateOpened",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DateReceived",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DateRegisterEntryCompleted",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DateSetupOnTramps",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DepositLetterLastLetterSent",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "DepositLetterTenantRef",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "OpeningBalance",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "PayingInBooksToGoTo",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "PrefferedCashbookID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "Reconciliations",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "RequestedDate",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "SortCode",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "StatementsAndReconciliations",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "TenancyReferenceNumber",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "TrampsCashbookId",
                schema: "app",
                table: "AccountOpenRequest");
        }
    }
}
