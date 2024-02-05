using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningWebApp.Migrations
{
    public partial class subfileremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCourseFiles");

            migrationBuilder.DropColumn(
                name: "SubCourseFilePath",
                table: "SubCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubCourseFilePath",
                table: "SubCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SubCourseFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCourseFiles", x => x.FileId);
                });
        }
    }
}
