using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    public partial class 打卡人变为打卡人id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "person",
                table: "punchclock");

            migrationBuilder.RenameColumn(
                name: "punchClockPerson",
                table: "punchclockrecord",
                newName: "punchClockPId");

            migrationBuilder.AddColumn<Guid>(
                name: "pid",
                table: "punchclock",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "发布人");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pid",
                table: "punchclock");

            migrationBuilder.RenameColumn(
                name: "punchClockPId",
                table: "punchclockrecord",
                newName: "punchClockPerson");

            migrationBuilder.AddColumn<string>(
                name: "person",
                table: "punchclock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "发布人");
        }
    }
}
