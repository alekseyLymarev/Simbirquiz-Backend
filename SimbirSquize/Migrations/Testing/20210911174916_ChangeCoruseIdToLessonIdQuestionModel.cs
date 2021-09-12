using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirSquize.Migrations.Testing
{
    public partial class ChangeCoruseIdToLessonIdQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_questions_Id",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "questions");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "questions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_questions_LessonId",
                table: "questions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lessons_Id",
                table: "questions",
                column: "Id",
                principalTable: "lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lessons_LessonId",
                table: "questions",
                column: "LessonId",
                principalTable: "lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessons_Id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessons_LessonId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_LessonId",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "questions");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "questions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_questions_Id",
                table: "lessons",
                column: "Id",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
