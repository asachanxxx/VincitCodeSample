using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddTicksAsTimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineAfterEventInDays",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.DropColumn(
                name: "TriggerBeforeEventInHours",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.AddColumn<long>(
                name: "DeadlineAfterEvent",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TriggerGapBeforeEvent",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineAfterEvent",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.DropColumn(
                name: "TriggerGapBeforeEvent",
                schema: "app",
                table: "ReconciliationSchedule");

            migrationBuilder.AddColumn<byte>(
                name: "DeadlineAfterEventInDays",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TriggerBeforeEventInHours",
                schema: "app",
                table: "ReconciliationSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
