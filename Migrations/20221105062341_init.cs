using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "管理员Id，唯一"),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户名"),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "密码"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "真实名称"),
                    sex = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    tel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "电话")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                },
                comment: "管理员表");

            migrationBuilder.CreateTable(
                name: "dormbuild",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id，唯一"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "宿舍楼名称"),
                    detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "详细说明")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormbuild", x => x.id);
                },
                comment: "存储宿舍楼信息");

            migrationBuilder.CreateTable(
                name: "dormmanager",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍管理员Id，唯一"),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户名，用于登录系统"),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "密码"),
                    dormBuildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id"),
                    dormBuildDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "宿舍楼详细说明"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "真实姓名"),
                    sex = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    tel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "电话")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormmanager", x => x.id);
                },
                comment: "主要存储宿舍管理员信息");

            migrationBuilder.CreateTable(
                name: "notice",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "公告Id，唯一"),
                    noticePerson = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "公告发布人"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "公告发布日期"),
                    content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "发布内容")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notice", x => x.id);
                },
                comment: "用于存储公告信息");

            migrationBuilder.CreateTable(
                name: "punchclock",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "打卡Id，唯一"),
                    theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "打卡主题"),
                    detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "打卡说明"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "发布日期"),
                    person = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "发布人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punchclock", x => x.id);
                },
                comment: "用于存储打卡发布记录");

            migrationBuilder.CreateTable(
                name: "punchclockrecord",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "记录Id，唯一"),
                    punchClockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "打卡Id"),
                    punchClockDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "发布日期"),
                    punchClockTheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "打卡主题"),
                    punchClockDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "打卡说明"),
                    punchClockPerson = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "打卡发布人"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "学生姓名"),
                    dormName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "寝室号"),
                    tel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "学生电话"),
                    stuNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "学生学号"),
                    dormBuildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id"),
                    isRecord = table.Column<int>(type: "int", nullable: false, comment: "是否已经打卡")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punchclockrecord", x => x.id);
                },
                comment: "用于存储打卡信息");

            migrationBuilder.CreateTable(
                name: "record",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "考勤Id，唯一"),
                    studentNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, comment: "学生学号"),
                    dormBuildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id"),
                    dormName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "寝室号"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "考勤日期"),
                    detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "详细说明")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record", x => x.id);
                },
                comment: "用于存储考勤记录");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "学生Id，唯一"),
                    stuNum = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, comment: "学生学号"),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "密码"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "姓名"),
                    dormBuildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "宿舍楼Id"),
                    dormName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "寝室号"),
                    sex = table.Column<int>(type: "int", nullable: false, comment: "性别"),
                    tel = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "电话")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                },
                comment: "学生表，用于存放学生信息");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "dormbuild");

            migrationBuilder.DropTable(
                name: "dormmanager");

            migrationBuilder.DropTable(
                name: "notice");

            migrationBuilder.DropTable(
                name: "punchclock");

            migrationBuilder.DropTable(
                name: "punchclockrecord");

            migrationBuilder.DropTable(
                name: "record");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
