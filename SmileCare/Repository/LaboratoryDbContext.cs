using Microsoft.EntityFrameworkCore;
using SmileCare.Domain;

namespace SmileCare.Repository
{
    public class LaboratoryDbContext : DbContext
    {
        public LaboratoryDbContext(DbContextOptions<LaboratoryDbContext> options):base(options)
        {

        }

        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Case> Cases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dentist>()
                .HasMany(c => c.Cases)
                .WithOne(d => d.Dentist);



            modelBuilder.Entity<Patient>()
                .HasMany(c => c.Cases)
                .WithOne(p => p.Patient);               

        }

    }
}
