using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID6",
                schema: "usr",
                table: "User",
                newName: "IX_ModifiedByID7");

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

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "app",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    RowModifiedOn = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                    table.ForeignKey(
                        name: "FK_Status_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "AccountOpenRequest",
                schema: "app",
                columns: table => new
                {
                    AccountOpenRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusID = table.Column<int>(type: "int", precision: 2, nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    RequestedOn = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false),
                    RequestedBy = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    RowModifiedOn = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpenRequest", x => x.AccountOpenRequestID);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_RequestedBy",
                        column: x => x.RequestedBy,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "app",
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOpenRequest_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "app",
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_RequestedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_TenantID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedBy",
                schema: "app",
                table: "AccountOpenRequest",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID4",
                schema: "app",
                table: "Status",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "UIX_StatusCode",
                schema: "app",
                table: "Status",
                column: "StatusCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOpenRequest",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "app");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ModifiedByID",
                schema: "app",
                table: "Tenant");

            migrationBuilder.RenameIndex(
                name: "IX_ModifiedByID7",
                schema: "usr",
                table: "User",
                newName: "IX_ModifiedByID6");

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
        }
    }
}
