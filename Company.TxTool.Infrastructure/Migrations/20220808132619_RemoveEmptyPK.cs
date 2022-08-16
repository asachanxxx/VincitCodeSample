using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveEmptyPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_SupportingDocumentation",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation");

            migrationBuilder.DropIndex(
                name: "IX_AccountOpenRequest_b_SupportingDocumentation_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation");

            migrationBuilder.DropColumn(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_SupportingDocumentation",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                column: "SupportDocumentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpenRequest_b_SupportingDocumentation",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation");

            migrationBuilder.AddColumn<int>(
                name: "AccountOpenRequestID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpenRequest_b_SupportingDocumentation",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                columns: new[] { "AccountOpenRequestID", "SupportDocumentID" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOpenRequest_b_SupportingDocumentation_SupportDocumentID",
                schema: "app",
                table: "AccountOpenRequest_b_SupportingDocumentation",
                column: "SupportDocumentID");
        }
    }
}
