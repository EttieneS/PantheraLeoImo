using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LionDevAPI.Migrations
{
    public partial class leave_table_completed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeaveAvailable",
                table: "Leaves",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LeaveTaken",
                table: "Leaves",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LeaveType",
                table: "Leaves",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveAvailable",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "LeaveTaken",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "LeaveType",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Leaves");
        }
    }
}
