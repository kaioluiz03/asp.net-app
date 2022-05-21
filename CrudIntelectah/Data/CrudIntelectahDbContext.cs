using Microsoft.EntityFrameworkCore;
using CrudIntelectah.Models;

namespace CrudIntelectah.Data
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");

    }
}