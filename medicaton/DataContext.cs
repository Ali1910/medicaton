using medicaton.models;
using Microsoft.EntityFrameworkCore;

namespace medicaton
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Medication> medications { get; set; }
        public DbSet<MedicationWarningJoin> medicationWarningJoins { get; set; }
        public DbSet<Warning> warnings { get; set; }
    }
}
