using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.Migrations
{
    /// <inheritdoc />
    public partial class 删除打卡相关数据库和增加寝室表2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_record",
                table: "record");

            migrationBuilder.RenameTable(
                name: "record",
                newName: "dormitory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dormitory",
                table: "dormitory",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dormitory",
                table: "dormitory");

            migrationBuilder.RenameTable(
                name: "dormitory",
                newName: "record");

            migrationBuilder.AddPrimaryKey(
                name: "PK_record",
                table: "record",
                column: "id");
        }
    }
}
