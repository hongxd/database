using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 删除宿舍管理员表中的宿舍信息只保留宿舍id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DormBuildName",
                table: "dormmanager");

            migrationBuilder.DropColumn(
                name: "dormBuildDetail",
                table: "dormmanager");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DormBuildName",
                table: "dormmanager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dormBuildDetail",
                table: "dormmanager",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "宿舍楼详细说明");
        }
    }
}
