using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirSquize.Migrations.Testing
{
    public partial class AddBaseEntityInterfaceWithCreatedAtUpdatedAtAndDeletedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
