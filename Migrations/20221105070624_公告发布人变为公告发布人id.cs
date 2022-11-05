using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    public partial class 公告发布人变为公告发布人id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "noticePerson",
                table: "notice",
                newName: "NoticePerson");

            migrationBuilder.AlterColumn<string>(
                name: "NoticePerson",
                table: "notice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "公告发布人");

            migrationBuilder.AddColumn<Guid>(
                name: "Pid",
                table: "notice",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "公告发布人");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pid",
                table: "notice");

            migrationBuilder.RenameColumn(
                name: "NoticePerson",
                table: "notice",
                newName: "noticePerson");

            migrationBuilder.AlterColumn<string>(
                name: "noticePerson",
                table: "notice",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "公告发布人",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
