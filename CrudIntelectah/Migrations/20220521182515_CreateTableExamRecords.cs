using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudIntelectah.Migrations
{
    public partial class CreateTableExamRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamRecords",
                columns: table => new
                {
                    ExamRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Observation = table.Column<string>(type: "TEXT", nullable: true),
                    IdForExamRecordType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRecords", x => x.ExamRecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamRecords");
        }
    }
}
