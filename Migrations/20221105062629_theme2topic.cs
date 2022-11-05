using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    public partial class theme2topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "punchClockTheme",
                table: "punchclockrecord",
                newName: "punchClockTopic");

            migrationBuilder.RenameColumn(
                name: "theme",
                table: "punchclock",
                newName: "topic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "punchClockTopic",
                table: "punchclockrecord",
                newName: "punchClockTheme");

            migrationBuilder.RenameColumn(
                name: "topic",
                table: "punchclock",
                newName: "theme");
        }
    }
}
