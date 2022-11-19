using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 删除宿舍管理员名字字段 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "managerName",
                table: "dormbuild");

            migrationBuilder.AlterColumn<Guid>(
                name: "dormmanager",
                table: "dormbuild",
                type: "uniqueidentifier",
                nullable: true,
                comment: "管理员id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "管理员");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "dormmanager",
                table: "dormbuild",
                type: "uniqueidentifier",
                nullable: true,
                comment: "管理员",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "管理员id");

            migrationBuilder.AddColumn<string>(
                name: "managerName",
                table: "dormbuild",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "管理员名称");
        }
    }
}
