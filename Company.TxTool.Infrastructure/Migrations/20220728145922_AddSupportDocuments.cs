using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddSupportDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportDocument",
                schema: "app",
                columns: table => new
                {
                    SupportDocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NewId())"),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SupportDocument", x => x.SupportDocumentID);
                    table.ForeignKey(
                        name: "FK_SupportDocument_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_SupportDocument_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalSchema: "lkp",
                        principalTable: "PicklistItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportDocument_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_SupportDocument_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportDocument_UploadedBy",
                        column: x => x.UploadedBy,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_CreatedByID",
                schema: "app",
                table: "SupportDocument",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_DocumentTypeID",
                schema: "app",
                table: "SupportDocument",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_ModifiedByID",
                schema: "app",
                table: "SupportDocument",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_TenantID",
                schema: "app",
                table: "SupportDocument",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportDocument_UploadedBy",
                schema: "app",
                table: "SupportDocument",
                column: "UploadedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportDocument",
                schema: "app");
        }
    }
}
