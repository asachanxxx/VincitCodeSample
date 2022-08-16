using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyConversion",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "lkp",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                    table.ForeignKey(
                        name: "FK_Currency_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoList_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_TodoList_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "CurrencyConversion",
                schema: "lkp",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false),
                    CurrencyCodeTo = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyCodeFrom = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CurrencyCodeFromTo = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false, computedColumnSql: "(([CurrencyCodeFrom]+'|')+[CurrencyCodeTo])", stored: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RateDivide = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyConversion", x => new { x.Year, x.CurrencyCodeTo, x.CurrencyCodeFrom });
                    table.ForeignKey(
                        name: "FK_CurrencyConversion_CurrencyCodeFrom",
                        column: x => x.CurrencyCodeFrom,
                        principalSchema: "lkp",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                    table.ForeignKey(
                        name: "FK_CurrencyConversion_CurrencyCodeTo",
                        column: x => x.CurrencyCodeTo,
                        principalSchema: "lkp",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                    table.ForeignKey(
                        name: "FK_CurrencyConversion_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Reminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(user_name())"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItem_CreatedByID",
                        column: x => x.CreatedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_TodoItem_ModifiedByID",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_ModifiedById",
                schema: "lkp",
                table: "Currency",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyName",
                schema: "lkp",
                table: "Currency",
                column: "CurrencyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyCodeFrom",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "CurrencyCodeFrom");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyCodeTo",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "CurrencyCodeTo");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyConversion_ModifiedById",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_CreatedByID",
                table: "TodoItems",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ModifiedByID",
                table: "TodoItems",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_CreatedByID",
                table: "TodoLists",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_ModifiedByID",
                table: "TodoLists",
                column: "ModifiedByID");
        }
    }
}
