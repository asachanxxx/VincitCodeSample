using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AccountCompositkeyV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_b_Document_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRegister_b_Document",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_b_Document_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.AlterColumn<int>(
                name: "AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRegister_b_Document",
                schema: "app",
                table: "AccountRegister_b_Document",
                columns: new[] { "AccountRegisterId", "SupportDocumentID" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_b_Document_SupportDocumentID",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "SupportDocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_b_Document_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "AccountRegisterId",
                principalSchema: "app",
                principalTable: "AccountRegister",
                principalColumn: "AccountRegisterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_b_Document_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRegister_b_Document",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_b_Document_SupportDocumentID",
                schema: "app",
                table: "AccountRegister_b_Document");

            migrationBuilder.AlterColumn<int>(
                name: "AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRegister_b_Document",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_b_Document_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "AccountRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_b_Document_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "AccountRegister_b_Document",
                column: "AccountRegisterId",
                principalSchema: "app",
                principalTable: "AccountRegister",
                principalColumn: "AccountRegisterID");
        }
    }
}
