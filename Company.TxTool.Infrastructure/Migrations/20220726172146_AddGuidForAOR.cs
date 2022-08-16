using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cushwake.TreasuryTool.Infrastructure.Migrations
{
    public partial class AddGuidForAOR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnderID",
                schema: "app",
                table: "Notification",
                newName: "OwnerID");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                schema: "app",
                table: "AccountOpenRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NewId())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                schema: "app",
                table: "AccountOpenRequest");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                schema: "app",
                table: "Notification",
                newName: "OwnderID");
        }
    }
}
