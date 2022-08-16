using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddTenantSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantID",
                schema: "usr",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "app",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantID",
                schema: "usr",
                table: "User",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEmail",
                schema: "app",
                table: "Tenant",
                column: "AdminEmail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User",
                column: "TenantID",
                principalSchema: "app",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TenantID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "app");

            migrationBuilder.DropIndex(
                name: "IX_User_TenantID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TenantID",
                schema: "usr",
                table: "User");
        }
    }
}
