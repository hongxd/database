using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 增加公告表中公告标题字段 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "发布内容");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "notice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "公告标题");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "notice");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "发布内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "发布内容");
        }
    }
}
