using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class npgSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "管理员Id，唯一"),
                    userName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "用户名"),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "密码"),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "真实名称"),
                    sex = table.Column<int>(type: "integer", nullable: true, comment: "性别"),
                    tel = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: true, comment: "电话")
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
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "宿舍楼Id，唯一"),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "宿舍楼名称"),
                    sex = table.Column<int>(type: "integer", nullable: false, comment: "宿舍楼居住人的性别"),
                    detail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "详细说明"),
                    dormmanager = table.Column<Guid>(type: "uuid", nullable: true, comment: "管理员id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormbuild", x => x.id);
                },
                comment: "存储宿舍楼信息");

            migrationBuilder.CreateTable(
                name: "dormitory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "寝室Id，唯一"),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "寝室名称"),
                    dormBuildId = table.Column<Guid>(type: "uuid", nullable: false, comment: "所属宿舍楼Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dormitory", x => x.id);
                },
                comment: "寝室管理");

            migrationBuilder.CreateTable(
                name: "dormmanager",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "宿舍管理员Id，唯一"),
                    userName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "用户名，用于登录系统"),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "密码"),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "真实姓名"),
                    sex = table.Column<int>(type: "integer", nullable: false, comment: "性别"),
                    tel = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "电话")
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
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公告Id，唯一"),
                    Pid = table.Column<Guid>(type: "uuid", nullable: false, comment: "公告发布人id"),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "公告发布日期"),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, comment: "发布内容"),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "公告标题")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notice", x => x.id);
                },
                comment: "用于存储公告信息");

            migrationBuilder.CreateTable(
                name: "repair",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "报修Id，唯一"),
                    thing = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "上报物品"),
                    detail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "物品详细描述"),
                    reportTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "上报时间"),
                    dormitoryId = table.Column<Guid>(type: "uuid", nullable: true, comment: "报修寝室"),
                    status = table.Column<int>(type: "integer", nullable: true, comment: "报修状态")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair", x => x.id);
                },
                comment: "用于存储报修记录");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "学生Id，唯一"),
                    stuNum = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false, comment: "学生学号"),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "密码"),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "姓名"),
                    dormitoryId = table.Column<Guid>(type: "uuid", nullable: false, comment: "寝室Id"),
                    sex = table.Column<int>(type: "integer", nullable: false, comment: "性别"),
                    tel = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false, comment: "电话")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                },
                comment: "学生表，用于存放学生信息");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "dormbuild");

            migrationBuilder.DropTable(
                name: "dormitory");

            migrationBuilder.DropTable(
                name: "dormmanager");

            migrationBuilder.DropTable(
                name: "notice");

            migrationBuilder.DropTable(
                name: "repair");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
