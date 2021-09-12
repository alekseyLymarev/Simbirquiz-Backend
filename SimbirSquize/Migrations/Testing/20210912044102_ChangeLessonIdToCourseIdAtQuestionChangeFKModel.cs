using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirSquize.Migrations.Testing
{
    public partial class ChangeLessonIdToCourseIdAtQuestionChangeFKModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_topics_Id",
                table: "questions");

            migrationBuilder.CreateIndex(
                name: "IX_questions_CourseId",
                table: "questions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_topics_CourseId",
                table: "questions",
                column: "CourseId",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_topics_CourseId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_CourseId",
                table: "questions");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_topics_Id",
                table: "questions",
                column: "Id",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
