using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DFDS.Migrations
{
    public partial class PassengerLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassengerLimit",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerLimit",
                table: "Bookings");
        }
    }
}
