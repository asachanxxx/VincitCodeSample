using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddAdditionalBridges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportDocument");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccountOpenRequest_b_DepositLetter",
                schema: "app",
                columns: table => new
                {
                    AccountOpenRequestID = table.Column<int>(type: "int", nullable: false),
                    SupportDocumentID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    PhysicalAccountOpenRequestId = table.Column<int>(type: "int", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    VirtualAccountOpenRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpenRequest_b_DepositLetter", x => new { x.AccountOpenRequestID, x.SupportDocumentID });
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_DepositLetter_AccountOpenRequest_PhysicalAccountOpenRequestId",
                        column: x => x.PhysicalAccountOpenRequestId,
                        principalSchema: "app",
                        principalTable: "AccountOpenRequest",
                        principalColumn: "AccountOpenRequestID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_DepositLetter_AccountOpenRequest_VirtualAccountOpenRequestId",
                        column: x => x.VirtualAccountOpenRequestId,
                        principalSchema: "app",
                        principalTable: "AccountOpenRequest",
                        principalColumn: "AccountOpenRequestID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_DepositLetter_SupportDocumentID",
                        column: x => x.SupportDocumentID,
                        principalSchema: "app",
                        principalTable: "SupportDocument",
                        principalColumn: "SupportDocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequestBDepositLetter_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountOpenRequest_b_LetterToBank",
                schema: "app",
                columns: table => new
                {
                    AccountOpenRequestID = table.Column<int>(type: "int", nullable: false),
                    SupportDocumentID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    PhysicalAccountOpenRequestId = table.Column<int>(type: "int", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    VirtualAccountOpenRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpenRequest_b_LetterToBank", x => new { x.AccountOpenRequestID, x.SupportDocumentID });
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_LetterToBank_AccountOpenRequest_PhysicalAccountOpenRequestId",
                        column: x => x.PhysicalAccountOpenRequestId,
                        principalSchema: "app",
                        principalTable: "AccountOpenRequest",
                        principalColumn: "AccountOpenRequestID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_LetterToBank_AccountOpenRequest_VirtualAccountOpenRequestId",
                        column: x => x.VirtualAccountOpenRequestId,
                        principalSchema: "app",
                        principalTable: "AccountOpenRequest",
                        principalColumn: "AccountOpenRequestID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_LetterToBank_SupportDocumentID",
                        column: x => x.SupportDocumentID,
                        principalSchema: "app",
                        principalTable: "SupportDocument",
                        principalColumn: "SupportDocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequestBLetterToBank_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountOpenRequest_b_SupportingDocumentation",
                schema: "app",
                columns: table => new
                {
                    AccountOpenRequestID = table.Column<int>(type: "int", nullable: false),
                    SupportDocumentID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    PhysicalAccountOpenRequestId = table.Column<int>(type: "int", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpenRequest_b_SupportingDocumentation", x => new { x.AccountOpenRequestID, x.SupportDocumentID });
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_SupportingDocumentation_AccountOpenRequest_PhysicalAccountOpenRequestId",
                        column: x => x.PhysicalAccountOpenRequestId,
                        principalSchema: "app",
                        principalTable: "AccountOpenRequest",
                        principalColumn: "AccountOpenRequestID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_b_SupportingDocumentation_SupportDocumentID",
                        column: x => x.SupportDocumentID,
                        principalSchema: "app",
                        principalTable: "SupportDocument",
                        principalColumn: "SupportDocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequestBSupportingDocumentation_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_PhysicalAccountOpenRequestId",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "PhysicalAccountOpenRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_TenantID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_VirtualAccountOpenRequestId",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "VirtualAccountOpenRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_PhysicalAccountOpenRequestId",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "PhysicalAccountOpenRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_TenantID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_VirtualAccountOpenRequestId",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "VirtualAccountOpenRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_SupportingDocumentation_PhysicalAccountOpenRequestId",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                column: "PhysicalAccountOpenRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_SupportingDocumentation_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_SupportingDocumentation_TenantID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                column: "TenantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOpenRequest_b_DepositLetter",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AccountOpenRequest_b_LetterToBank",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AccountOpenRequest_b_SupportingDocumentation",
                schema: "app");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "usr",
                table: "ApplicationRole_b_Permission");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOfOpeninigBalanceMovedToAccount",
                schema: "app",
                table: "AccountOpenRequest",
                type: "decimal(2,2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SupportDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())")
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
                        name: "FK_SupportDocument_PicklistItem_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "lkp",
                        principalTable: "PicklistItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_CreatedByID",
                table: "SupportDocument",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_DocumentTypeId",
                table: "SupportDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_ModifiedByID",
                table: "SupportDocument",
                column: "ModifiedByID");
        }
    }
}
