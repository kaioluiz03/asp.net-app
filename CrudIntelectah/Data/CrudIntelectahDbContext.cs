using Microsoft.EntityFrameworkCore;
using CrudIntelectah.Models;

namespace CrudIntelectah.Data
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TypeOfExam> TypeOfExams { get; set; }
        public DbSet<ExamRecord> ExamRecords  { get; set; }
        public DbSet<AppointmentScheduling> AppointmentsScheduling { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");

    }
}