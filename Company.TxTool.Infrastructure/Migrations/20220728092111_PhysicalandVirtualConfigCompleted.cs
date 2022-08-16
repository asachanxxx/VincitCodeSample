using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class PhysicalandVirtualConfigCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportDocument_PicklistItem_documentTypeId",
                table: "SupportDocument");

            migrationBuilder.DropColumn(
                name: "OpeningBalance",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "documentTypeId",
                table: "SupportDocument",
                newName: "DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "documentLink",
                table: "SupportDocument",
                newName: "DocumentLink");

            migrationBuilder.RenameIndex(
                name: "IX_SupportDocument_documentTypeId",
                table: "SupportDocument",
                newName: "IX_SupportDocument_DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "StatementsAndReconciliations",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "VirtualAccountNumber");

            migrationBuilder.RenameColumn(
                name: "Reconciliations",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "TransactionTypeCode");

            migrationBuilder.RenameColumn(
                name: "DateSetupOnTramps",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "DateSetupOnDatabase");

            migrationBuilder.RenameColumn(
                name: "BibSetupdatedOn",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AccountGroupUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "BibSet",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "TenantName");

            migrationBuilder.RenameColumn(
                name: "BankSortCode",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "ScheduleRef");

            migrationBuilder.RenameColumn(
                name: "BankNameRe2",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "ReconciliationFrequency");

            migrationBuilder.RenameColumn(
                name: "BankName",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "PropertyNumber");

            migrationBuilder.RenameColumn(
                name: "BankAccountNumber",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "PostingRulesInBMAPDebtorClientRef");

            migrationBuilder.RenameColumn(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "ExpenseCode");

            migrationBuilder.AddColumn<string>(
                name: "AccountGroup",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountName",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChartCode",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportDocument_PicklistItem_DocumentTypeId",
                table: "SupportDocument",
                column: "DocumentTypeId",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportDocument_PicklistItem_DocumentTypeId",
                table: "SupportDocument");

            migrationBuilder.DropColumn(
                name: "AccountGroup",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankAccountName",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "BankID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "ChartCode",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                table: "SupportDocument",
                newName: "documentTypeId");

            migrationBuilder.RenameColumn(
                name: "DocumentLink",
                table: "SupportDocument",
                newName: "documentLink");

            migrationBuilder.RenameIndex(
                name: "IX_SupportDocument_DocumentTypeId",
                table: "SupportDocument",
                newName: "IX_SupportDocument_documentTypeId");

            migrationBuilder.RenameColumn(
                name: "VirtualAccountNumber",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "StatementsAndReconciliations");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeCode",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "Reconciliations");

            migrationBuilder.RenameColumn(
                name: "TenantName",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BibSet");

            migrationBuilder.RenameColumn(
                name: "ScheduleRef",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BankSortCode");

            migrationBuilder.RenameColumn(
                name: "ReconciliationFrequency",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BankNameRe2");

            migrationBuilder.RenameColumn(
                name: "PropertyNumber",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BankName");

            migrationBuilder.RenameColumn(
                name: "PostingRulesInBMAPDebtorClientRef",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BankAccountNumber");

            migrationBuilder.RenameColumn(
                name: "ExpenseCode",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AnyOtherInformation");

            migrationBuilder.RenameColumn(
                name: "DateSetupOnDatabase",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "DateSetupOnTramps");

            migrationBuilder.RenameColumn(
                name: "AccountGroupUpdatedOn",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "BibSetupdatedOn");

            migrationBuilder.AddColumn<string>(
                name: "OpeningBalance",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(max)",
                precision: 2,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportDocument_PicklistItem_documentTypeId",
                table: "SupportDocument",
                column: "documentTypeId",
                principalSchema: "lkp",
                principalTable: "PicklistItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
