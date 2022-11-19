using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 宿舍楼表配置管理员 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "managerName",
                table: "dormbuild",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "管理员名称");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "managerName",
                table: "dormbuild");
        }
    }
}
