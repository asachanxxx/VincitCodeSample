using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.EnsureSchema(
                name: "usr");

            migrationBuilder.EnsureSchema(
                name: "lkp");

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Reminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppConfig",
                schema: "app",
                columns: table => new
                {
                    AppConfigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppConfigCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AppConfigName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AppConfigText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedbyID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.AppConfigID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                schema: "usr",
                columns: table => new
                {
                    ApplicationRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationRoleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationRoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsStandardRole = table.Column<bool>(type: "bit", nullable: false),
                    CopiedFromApplicationRoleID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.ApplicationRoleID);
                    table.ForeignKey(
                        name: "FK_ApplicationRole_CopiedFromApplicationRoleID",
                        column: x => x.CopiedFromApplicationRoleID,
                        principalSchema: "usr",
                        principalTable: "ApplicationRole",
                        principalColumn: "ApplicationRoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "usr",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGraphID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ApplicationRoleID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_ApplicationRoleID",
                        column: x => x.ApplicationRoleID,
                        principalSchema: "usr",
                        principalTable: "ApplicationRole",
                        principalColumn: "ApplicationRoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "lkp",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                    table.ForeignKey(
                        name: "FK_Currency_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ErrorMessage",
                schema: "app",
                columns: table => new
                {
                    ErrorMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorMessageCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ErrorMessageName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ErrorMessageText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedbyID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorMessage", x => x.ErrorMessageID);
                    table.ForeignKey(
                        name: "FK_ErrorMessage_ModifiedBy",
                        column: x => x.ModifiedbyID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "usr",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MemberOrderKey = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permission_ModifiedBy",
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
                    CurrencyCodeFrom = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyCodeTo = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyCodeFromTo = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false, computedColumnSql: "(([CurrencyCodeFrom]+'|')+[CurrencyCodeTo])", stored: true),
                    RateDivide = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValueSql: "((1))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
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
                        name: "FK_CurrencyConversion_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRole_b_Permission",
                schema: "usr",
                columns: table => new
                {
                    ApplicationRoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: true),
                    ModifiedByID = table.Column<int>(type: "int", nullable: true),
                    RowModified = table.Column<DateTime>(type: "datetime2(2)", precision: 2, nullable: false, defaultValueSql: "(getdate())"),
                    RowModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(user_name())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole_b_Permission", x => new { x.ApplicationRoleID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_ApplicationRole_b_Permission_ApplicationRole",
                        column: x => x.ApplicationRoleID,
                        principalSchema: "usr",
                        principalTable: "ApplicationRole",
                        principalColumn: "ApplicationRoleID");
                    table.ForeignKey(
                        name: "FK_ApplicationRole_b_Permission_ModifiedBy",
                        column: x => x.ModifiedByID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_ApplicationRole_b_Permission_Permission",
                        column: x => x.PermissionID,
                        principalSchema: "usr",
                        principalTable: "Permission",
                        principalColumn: "PermissionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigName",
                schema: "app",
                table: "AppConfig",
                column: "AppConfigName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID",
                schema: "app",
                table: "AppConfig",
                column: "ModifiedbyID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_CopiedFromApplicationRoleID",
                schema: "usr",
                table: "ApplicationRole",
                column: "CopiedFromApplicationRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_ModifiedByID",
                schema: "usr",
                table: "ApplicationRole",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID4",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionID",
                schema: "usr",
                table: "ApplicationRole_b_Permission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyName",
                schema: "lkp",
                table: "Currency",
                column: "CurrencyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID2",
                schema: "lkp",
                table: "Currency",
                column: "ModifiedByID");

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
                name: "IX_ModifiedByID3",
                schema: "lkp",
                table: "CurrencyConversion",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageName",
                schema: "app",
                table: "ErrorMessage",
                column: "ErrorMessageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID1",
                schema: "app",
                table: "ErrorMessage",
                column: "ModifiedbyID");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID5",
                schema: "usr",
                table: "Permission",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "UIX_PermissionCode",
                schema: "usr",
                table: "Permission",
                column: "PermissionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoleID",
                schema: "usr",
                table: "User",
                column: "ApplicationRoleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedByID6",
                schema: "usr",
                table: "User",
                column: "ModifiedByID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGraphID",
                schema: "usr",
                table: "User",
                column: "UserGraphID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkEmail",
                schema: "usr",
                table: "User",
                column: "WorkEmail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppConfig_User",
                schema: "app",
                table: "AppConfig",
                column: "ModifiedbyID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole",
                column: "ModifiedByID",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_ModifiedBy",
                schema: "usr",
                table: "ApplicationRole");

            migrationBuilder.DropTable(
                name: "AppConfig",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ApplicationRole_b_Permission",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "CurrencyConversion",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "ErrorMessage",
                schema: "app");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "User",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "ApplicationRole",
                schema: "usr");
        }
    }
}
