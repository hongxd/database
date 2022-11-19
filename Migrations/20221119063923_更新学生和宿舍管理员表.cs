using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 更新学生和宿舍管理员表 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "student",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "宿舍楼名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "寝室号");

            migrationBuilder.AlterColumn<string>(
                name: "studentNumber",
                table: "record",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                comment: "学生学号",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldComment: "学生学号");

            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "record",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "寝室号",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "寝室号");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "record",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "详细说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "record",
                type: "datetime2",
                nullable: true,
                comment: "考勤日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "考勤日期");

            migrationBuilder.AlterColumn<string>(
                name: "tel",
                table: "punchclockrecord",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                comment: "学生电话",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldComment: "学生电话");

            migrationBuilder.AlterColumn<string>(
                name: "stuNum",
                table: "punchclockrecord",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "学生学号",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "学生学号");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockTopic",
                table: "punchclockrecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "打卡主题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "打卡主题");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockPId",
                table: "punchclockrecord",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "打卡发布人",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "打卡发布人");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockDetail",
                table: "punchclockrecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "打卡说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "打卡说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "punchClockDate",
                table: "punchclockrecord",
                type: "datetime2",
                nullable: true,
                comment: "发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "发布日期");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "punchclockrecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "学生姓名",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "学生姓名");

            migrationBuilder.AlterColumn<int>(
                name: "isRecord",
                table: "punchclockrecord",
                type: "int",
                nullable: true,
                comment: "是否已经打卡",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "是否已经打卡");

            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "punchclockrecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "寝室号",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "寝室号");

            migrationBuilder.AlterColumn<string>(
                name: "topic",
                table: "punchclock",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "打卡主题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "打卡主题");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "punchclock",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "打卡说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "打卡说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "punchclock",
                type: "datetime2",
                nullable: true,
                comment: "发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "发布日期");

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
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "发布内容");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "dormmanager",
                type: "uniqueidentifier",
                nullable: true,
                comment: "宿舍楼Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "宿舍楼Id");

            migrationBuilder.AlterColumn<string>(
                name: "dormBuildDetail",
                table: "dormmanager",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "宿舍楼详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "宿舍楼详细说明");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "dormbuild",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "宿舍楼名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "宿舍楼名称");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "dormbuild",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "详细说明");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "admin",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "用户名",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "用户名");

            migrationBuilder.AlterColumn<string>(
                name: "tel",
                table: "admin",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                comment: "电话",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldComment: "电话");

            migrationBuilder.AlterColumn<int>(
                name: "sex",
                table: "admin",
                type: "int",
                nullable: true,
                comment: "性别",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "性别");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "admin",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "密码");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "admin",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "真实名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "真实名称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "student",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "寝室号",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "宿舍楼名称");

            migrationBuilder.AlterColumn<string>(
                name: "studentNumber",
                table: "record",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "学生学号",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "学生学号");

            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "record",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "寝室号",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "寝室号");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "record",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "详细说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "record",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "考勤日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "考勤日期");

            migrationBuilder.AlterColumn<string>(
                name: "tel",
                table: "punchclockrecord",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                comment: "学生电话",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true,
                oldComment: "学生电话");

            migrationBuilder.AlterColumn<string>(
                name: "stuNum",
                table: "punchclockrecord",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "学生学号",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "学生学号");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockTopic",
                table: "punchclockrecord",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "打卡主题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "打卡主题");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockPId",
                table: "punchclockrecord",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "打卡发布人",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "打卡发布人");

            migrationBuilder.AlterColumn<string>(
                name: "punchClockDetail",
                table: "punchclockrecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "打卡说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "打卡说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "punchClockDate",
                table: "punchclockrecord",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "发布日期");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "punchclockrecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "学生姓名",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "学生姓名");

            migrationBuilder.AlterColumn<int>(
                name: "isRecord",
                table: "punchclockrecord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "是否已经打卡",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "是否已经打卡");

            migrationBuilder.AlterColumn<string>(
                name: "dormName",
                table: "punchclockrecord",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "寝室号",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "寝室号");

            migrationBuilder.AlterColumn<string>(
                name: "topic",
                table: "punchclock",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "打卡主题",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "打卡主题");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "punchclock",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "打卡说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "打卡说明");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "punchclock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "发布日期");

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
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "发布内容");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormBuildId",
                table: "dormmanager",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "宿舍楼Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "宿舍楼Id");

            migrationBuilder.AlterColumn<string>(
                name: "dormBuildDetail",
                table: "dormmanager",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "宿舍楼详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "宿舍楼详细说明");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "dormbuild",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "宿舍楼名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "宿舍楼名称");

            migrationBuilder.AlterColumn<string>(
                name: "detail",
                table: "dormbuild",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "详细说明",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "详细说明");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "admin",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "用户名",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "用户名");

            migrationBuilder.AlterColumn<string>(
                name: "tel",
                table: "admin",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                comment: "电话",
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true,
                oldComment: "电话");

            migrationBuilder.AlterColumn<int>(
                name: "sex",
                table: "admin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "性别",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "性别");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "admin",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "密码");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "admin",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "真实名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "真实名称");
        }
    }
}
