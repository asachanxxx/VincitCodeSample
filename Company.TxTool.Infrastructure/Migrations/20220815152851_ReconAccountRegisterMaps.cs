using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class ReconAccountRegisterMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReconciliationSchedule_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ReconciliationSchedule_User_ReviewedById",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ReconciliationSchedule_AccountRegisterId",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Frequency",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OriginFrequency",
                schema: "app",
                table: "Reconciliation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountRegister_ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister",
                column: "ReconciliationScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRegister_ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister",
                column: "ReconciliationScheduleId",
                principalSchema: "app",
                principalTable: "ReconciliationSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciliationSchedule_ReviewedById",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "ReviewedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRegister_ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_ReconciliationSchedule_ReviewedById",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.DropIndex(
                name: "IX_AccountRegister_ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.DropColumn(
                name: "ReconciliationScheduleId",
                schema: "app",
                table: "AccountRegister");

            migrationBuilder.AlterColumn<string>(
                name: "Frequency",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<byte>(
                name: "OriginFrequency",
                schema: "app",
                table: "Reconciliation",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_ReconciliationSchedule_AccountRegisterId",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "AccountRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciliationSchedule_AccountRegister_AccountRegisterId",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "AccountRegisterId",
                principalSchema: "app",
                principalTable: "AccountRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciliationSchedule_User_ReviewedById",
                schema: "app",
                table: "ReconciliationSchedule",
                column: "ReviewedById",
                principalSchema: "usr",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
