using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 增加报修管理表 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "punchclock");

            migrationBuilder.CreateTable(
                name: "repair",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "报修Id，唯一"),
                    thing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "上报物品"),
                    detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "物品详细描述"),
                    reportTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "上报时间"),
                    status = table.Column<int>(type: "int", nullable: true, comment: "报修状态")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair", x => x.id);
                },
                comment: "用于存储报修记录");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "repair");

            migrationBuilder.CreateTable(
                name: "punchclock",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "打卡Id，唯一"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布日期"),
                    detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "打卡说明"),
                    pid = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false, comment: "发布人"),
                    topic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "打卡主题")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punchclock", x => x.id);
                },
                comment: "用于存储打卡发布记录");
        }
    }
}
