using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 公告表所有字段必填 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "notice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "公告标题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "公告标题");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "notice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "公告发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "公告发布日期");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "发布内容");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "notice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "公告标题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "公告标题");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "notice",
                type: "datetime2",
                nullable: true,
                comment: "公告发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "公告发布日期");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "发布内容");
        }
    }
}
