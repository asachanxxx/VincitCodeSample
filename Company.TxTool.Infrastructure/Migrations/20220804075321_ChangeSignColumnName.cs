using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class ChangeSignColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sign",
                schema: "lkp",
                table: "PicklistItem",
                newName: "CurrencySign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrencySign",
                schema: "lkp",
                table: "PicklistItem",
                newName: "Sign");
        }
    }
}
