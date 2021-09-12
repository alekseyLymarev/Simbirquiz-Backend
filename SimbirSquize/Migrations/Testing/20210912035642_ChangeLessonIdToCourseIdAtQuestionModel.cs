using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirSquize.Migrations.Testing
{
    public partial class ChangeLessonIdToCourseIdAtQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_topics_Id",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessons_Id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessons_LessonId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_answers_questions_TestId",
                table: "test_answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_answers",
                table: "test_answers");

            migrationBuilder.DropIndex(
                name: "IX_questions_LessonId",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "questions",
                newName: "CourseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestId",
                table: "test_answers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "test_answers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_answers",
                table: "test_answers",
                columns: new[] { "QuestionId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_test_answers_TestId",
                table: "test_answers",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_topics_Id",
                table: "questions",
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_topics_Id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_answers_questions_TestId",
                table: "test_answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_answers",
                table: "test_answers");

            migrationBuilder.DropIndex(
                name: "IX_test_answers_TestId",
                table: "test_answers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "test_answers");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "questions",
                newName: "LessonId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestId",
                table: "test_answers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_answers",
                table: "test_answers",
                columns: new[] { "TestId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_questions_LessonId",
                table: "questions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_topics_Id",
                table: "lessons",
                column: "Id",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_test_answers_questions_TestId",
                table: "test_answers",
                column: "TestId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
