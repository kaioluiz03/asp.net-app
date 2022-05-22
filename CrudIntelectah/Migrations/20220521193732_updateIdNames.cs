using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudIntelectah.Migrations
{
    public partial class updateIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfExamId",
                table: "TypeOfExams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdForExamRecordType",
                table: "ExamRecords",
                newName: "TypeOfExamId");

            migrationBuilder.RenameColumn(
                name: "ExamRecordId",
                table: "ExamRecords",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeOfExams",
                newName: "TypeOfExamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "TypeOfExamId",
                table: "ExamRecords",
                newName: "IdForExamRecordType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamRecords",
                newName: "ExamRecordId");
        }
    }
}
