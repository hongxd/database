using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 宿舍楼增加宿舍管理员属性 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "dormmanager",
                table: "dormbuild",
                type: "uniqueidentifier",
                nullable: true,
                comment: "管理员");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dormmanager",
                table: "dormbuild");
        }
    }
}
