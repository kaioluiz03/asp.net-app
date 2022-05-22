using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudIntelectah.Migrations
{
    public partial class CreateTableAppointmentScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentsScheduling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<string>(type: "TEXT", nullable: true),
                    ExamRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsultationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProtocolNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsScheduling", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentsScheduling");
        }
    }
}
