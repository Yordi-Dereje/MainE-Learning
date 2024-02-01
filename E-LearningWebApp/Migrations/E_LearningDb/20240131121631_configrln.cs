using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningWebApp.Migrations.E_LearningDb
{
    public partial class configrln : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SubCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCourses_CourseId",
                table: "SubCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCourses_Courses_CourseId",
                table: "SubCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCourses_Courses_CourseId",
                table: "SubCourses");

            migrationBuilder.DropIndex(
                name: "IX_SubCourses_CourseId",
                table: "SubCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SubCourses");
        }
    }
}
