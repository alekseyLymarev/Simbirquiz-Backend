using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirSquize.Migrations.Testing
{
    public partial class ChangeTestModelToQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_answers_tests_TestId",
                table: "test_answers");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QuestionText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_questions_Id",
                table: "lessons",
                column: "Id",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_topics_Id",
                table: "lessons",
                column: "Id",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_answers_questions_TestId",
                table: "test_answers",
                column: "TestId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_questions_Id",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_lessons_topics_Id",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_test_answers_questions_TestId",
                table: "test_answers");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Question = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_test_answers_tests_TestId",
                table: "test_answers",
                column: "TestId",
                principalTable: "tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
