using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 删除宿舍管理员表中的宿舍id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dormBuildId",
                table: "dormmanager");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "dormBuildId",
                table: "dormmanager",
                type: "uniqueidentifier",
                nullable: true,
                comment: "宿舍楼Id");
        }
    }
}
