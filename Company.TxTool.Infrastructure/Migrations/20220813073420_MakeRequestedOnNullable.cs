using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class MakeRequestedOnNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedOn",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedOn",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2(2)",
                precision: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(2)",
                oldPrecision: 2,
                oldNullable: true);
        }
    }
}
