using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class ChangeStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "app");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "StatusID",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "tinyint",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "app",
                table: "AccountOpenRequest",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_Status",
                schema: "app",
                table: "AccountOpenRequest",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_Status",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "app",
                table: "AccountOpenRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "app",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "StatusID");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ApplicationRole_Type",
                schema: "app",
                table: "AccountOpenRequest",
                sql: "[Type]='Physical' OR [Type]='Virtual'");

            migrationBuilder.CreateIndex(
                name: "UIX_StatusCode",
                schema: "app",
                table: "Status",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpenRequest_StatusID",
                schema: "app",
                table: "AccountOpenRequest",
                column: "StatusID",
                principalSchema: "app",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
