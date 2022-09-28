using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LionDevAPI.Migrations
{
    public partial class leave_added_dates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Leaves");
        }
    }
}
