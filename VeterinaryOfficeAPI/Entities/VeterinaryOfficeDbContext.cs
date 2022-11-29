using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryOfficeAPI.Entities
{
    public class VeterinaryOfficeDbContext : DbContext 
    {
        private string _connectionString = "Server=(localdb)\\Local; Database=VeterinaryOfficeDb; Trusted_Connection=True";
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Visit> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne<Visit>(a => a.Visit)
                .WithOne(v => v.Animal)
                .HasForeignKey<Visit>(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Owner>()
                .HasMany<Animal>(o => o.Animals)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Animal>()
                .Property(a => a.Weight)
                .HasPrecision(6, 2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    
}
