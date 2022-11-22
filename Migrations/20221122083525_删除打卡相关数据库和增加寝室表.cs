using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 删除打卡相关数据库和增加寝室表 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "record");

            migrationBuilder.DropColumn(
                name: "detail",
                table: "record");

            migrationBuilder.DropColumn(
                name: "dormName",
                table: "record");

            migrationBuilder.DropColumn(
                name: "studentNumber",
                table: "record");

            migrationBuilder.AlterTable(
                name: "record",
                comment: "寝室管理",
                oldComment: "用于存储考勤记录");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "student",
                type: "uniqueidentifier",
                nullable: false,
                comment: "寝室Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "宿舍楼Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "record",
                type: "uniqueidentifier",
                nullable: false,
                comment: "所属宿舍楼Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "宿舍楼Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "record",
                type: "uniqueidentifier",
                nullable: false,
                comment: "寝室Id，唯一",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "考勤Id，唯一");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "record",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "寝室名称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "record");

            migrationBuilder.AlterTable(
                name: "record",
                comment: "用于存储考勤记录",
                oldComment: "寝室管理");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "student",
                type: "uniqueidentifier",
                nullable: false,
                comment: "宿舍楼Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "寝室Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "record",
                type: "uniqueidentifier",
                nullable: false,
                comment: "宿舍楼Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "所属宿舍楼Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "record",
                type: "uniqueidentifier",
                nullable: false,
                comment: "考勤Id，唯一",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "寝室Id，唯一");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "record",
                type: "datetime2",
                nullable: true,
                comment: "考勤日期");

            migrationBuilder.AddColumn<string>(
                name: "detail",
                table: "record",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "详细说明");

            migrationBuilder.AddColumn<string>(
                name: "dormName",
                table: "record",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "寝室号");

            migrationBuilder.AddColumn<string>(
                name: "studentNumber",
                table: "record",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                comment: "学生学号");
        }
    }
}
