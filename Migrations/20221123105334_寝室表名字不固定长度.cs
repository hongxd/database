using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 寝室表名字不固定长度 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "punchclockrecord");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "dormitory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "寝室名称",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldComment: "寝室名称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "dormitory",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                comment: "寝室名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "寝室名称");

            migrationBuilder.CreateTable(
                name: "punchclockrecord",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "记录Id，唯一"),
                    dormBuildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id"),
                    dormName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "寝室号"),
                    isRecord = table.Column<int>(type: "int", nullable: true, comment: "是否已经打卡"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "学生姓名"),
                    punchClockDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布日期"),
                    punchClockDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "打卡说明"),
                    punchClockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "打卡Id"),
                    punchClockPId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "打卡发布人"),
                    punchClockTopic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "打卡主题"),
                    stuNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "学生学号"),
                    tel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true, comment: "学生电话")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punchclockrecord", x => x.id);
                },
                comment: "用于存储打卡信息");
        }
    }
}
