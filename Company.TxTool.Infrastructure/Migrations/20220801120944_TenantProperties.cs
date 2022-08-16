using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class TenantProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDate",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.AddColumn<string>(
                name: "CultureCode",
                schema: "app",
                table: "Tenant",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "en-GB");

            migrationBuilder.AddColumn<string>(
                name: "TimeZoneName",
                schema: "app",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "Sri Lanka Standard Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CultureCode",
                schema: "app",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "TimeZoneName",
                schema: "app",
                table: "Tenant");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDate",
                schema: "app",
                table: "AccountOpenRequest",
                type: "datetime2",
                nullable: true);
        }
    }
}
