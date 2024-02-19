using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningWebApp.Migrations.E_LearningDb
{
    public partial class removeuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Id",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "E_LearningWebAppUserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_E_LearningWebAppUserId",
                table: "Payments",
                column: "E_LearningWebAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_E_LearningWebAppUserId",
                table: "Payments",
                column: "E_LearningWebAppUserId",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_E_LearningWebAppUserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_E_LearningWebAppUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "E_LearningWebAppUserId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Id",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_Id",
                table: "Payments",
                column: "Id",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
