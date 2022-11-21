using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 公告表取消发布人id长度限制 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Pid",
                table: "notice",
                type: "uniqueidentifier",
                nullable: false,
                comment: "公告发布人id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 20,
                oldComment: "公告发布人");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Pid",
                table: "notice",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                comment: "公告发布人",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "公告发布人id");
        }
    }
}
