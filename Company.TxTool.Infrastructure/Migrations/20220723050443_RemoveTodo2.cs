using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class RemoveTodo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PicklistItem_Type",
                schema: "lkp",
                table: "PicklistItem");

            migrationBuilder.DropTable(
                name: "PicklistType",
                schema: "lkp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PicklistType",
                schema: "lkp",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicklistType", x => x.Code);
                });

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
    }
}
