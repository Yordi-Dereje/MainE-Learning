using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningWebApp.Migrations.E_LearningDb
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_UserId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                newName: "IX_Payments_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_Id",
                table: "Payments",
                column: "Id",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_Id",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_Id",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
