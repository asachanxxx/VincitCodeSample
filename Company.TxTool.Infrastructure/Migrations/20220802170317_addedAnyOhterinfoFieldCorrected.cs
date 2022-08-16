using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class addedAnyOhterinfoFieldCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnyOtherInfromation",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AnyOtherInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnyOtherInformation",
                schema: "app",
                table: "AccountOpenRequest",
                newName: "AnyOtherInfromation");
        }
    }
}
