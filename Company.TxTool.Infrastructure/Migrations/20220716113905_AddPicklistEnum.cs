using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddPicklistEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem",
                column: "Type",
                principalSchema: "lkp",
                principalTable: "PicklistType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropIndex(
                name: "IX_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem");
        }
    }
}
