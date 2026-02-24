using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Models;

namespace VetClinicAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VetDoctor> VetDoctors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetProfile> PetProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<VetDoctor>().HasData(
                new VetDoctor { Id = 1, Name = "Dr. Alice Smith", Specialty = "Surgery" },
                new VetDoctor { Id = 2, Name = "Dr. Bob Johnson", Specialty = "Dentistry" },
                new VetDoctor { Id = 3, Name = "Dr. Carol Lee", Specialty = "Dermatology" }
            );

           
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, MicrochipId = "MC1001", Name = "Buddy", Species = "Dog", VetDoctorId = 1 },
                new Pet { Id = 2, MicrochipId = "MC1002", Name = "Whiskers", Species = "Cat", VetDoctorId = 2 },
                new Pet { Id = 3, MicrochipId = "MC1003", Name = "Chirpy", Species = "Bird", VetDoctorId = 3 },
                new Pet { Id = 4, MicrochipId = "MC1004", Name = "Nibbles", Species = "Rabbit", VetDoctorId = 1 }
            );

           
            modelBuilder.Entity<PetProfile>().HasData(
                new PetProfile { Id = 1, PetId = 1, VetNotes = "Healthy, needs annual vaccination." },
                new PetProfile { Id = 2, PetId = 2, VetNotes = "Dental cleaning scheduled next month." },
                new PetProfile { Id = 3, PetId = 3, VetNotes = "Feather condition normal, check diet." },
                new PetProfile { Id = 4, PetId = 4, VetNotes = "Monitor weight, eating well." }
            );
        }
    }
}
