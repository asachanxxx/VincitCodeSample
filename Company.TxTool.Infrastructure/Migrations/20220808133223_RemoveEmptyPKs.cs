using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveEmptyPKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_LetterToBank",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_DepositLetter",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter");

            migrationBuilder.DropColumn(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank");

            migrationBuilder.DropColumn(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter");

            migrationBuilder.RenameIndex(
                name: "IX_WorkEmail",
                schema: "usr",
                table: "User",
                newName: "UIX_User_WorkEmail");

            migrationBuilder.RenameIndex(
                name: "IX_UserGraphID",
                schema: "usr",
                table: "User",
                newName: "UIX_User_UserGraphID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRoleID",
                schema: "usr",
                table: "User",
                newName: "UIX_User_ApplicationRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_LetterToBank",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "SupportDocumentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_DepositLetter",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "UIX_SupportDocument_Guid",
                schema: "app",
                table: "SupportDocument",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIX_AccountOpenRequest_Guid",
                schema: "app",
                table: "AccountOpenRequest",
                column: "Guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UIX_SupportDocument_Guid",
                schema: "app",
                table: "SupportDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_LetterToBank",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_DepositLetter",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter");

            migrationBuilder.DropIndex(
                name: "UIX_AccountOpenRequest_Guid",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameIndex(
                name: "UIX_User_WorkEmail",
                schema: "usr",
                table: "User",
                newName: "IX_WorkEmail");

            migrationBuilder.RenameIndex(
                name: "UIX_User_UserGraphID",
                schema: "usr",
                table: "User",
                newName: "IX_UserGraphID");

            migrationBuilder.RenameIndex(
                name: "UIX_User_ApplicationRoleID",
                schema: "usr",
                table: "User",
                newName: "IX_ApplicationRoleID");

            migrationBuilder.AddColumn<int>(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_LetterToBank",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                columns: new[] { "AccountOpenRequestID", "SupportDocumentID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_DepositLetter",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                columns: new[] { "AccountOpenRequestID", "SupportDocumentID" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_LetterToBank_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_LetterToBank",
                column: "SupportDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_DepositLetter_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_DepositLetter",
                column: "SupportDocumentID");
        }
    }
}
