using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningWebApp.Migrations.E_LearningDb
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Userid",
                table: "Grades",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "E_LearningWebAppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_LearningWebAppUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Userid",
                table: "Grades",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_E_LearningWebAppUser_Userid",
                table: "Grades",
                column: "Userid",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "E_LearningWebAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_E_LearningWebAppUser_Userid",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_E_LearningWebAppUser_UserId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "E_LearningWebAppUser");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Userid",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Grades");
        }
    }
}
