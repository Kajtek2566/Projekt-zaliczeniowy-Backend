using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base (options) 
        { }

        public DbSet<Animal> Animals { get; set; } = default!;
        public DbSet<ZooUser> AnimalOwners { get; set; } = default!;
        public DbSet<AnimalSponsor> AnimalSponsors { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZooUser>()
                .HasMany(u => u.AnimalSponsors)
                .WithOne(r => r.ZooUser)
                .HasForeignKey(r => r.zooUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja relacji Car-Rental (jeden do wielu)
            builder.Entity<Animal>()
                .HasMany(c => c.AnimalSponsors)
                .WithOne(r => r.Animal)
                .HasForeignKey(r => r.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ZooUser>().HasData(
                new ZooUser
                {
                    Id = 1,
                    Login = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123!@#"),
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@domain.com",
                    PhoneNumber = "111222333",
                    Role = "Admin"
                },
                new ZooUser
                {
                    Id = 2,
                    Login = "Kajetan25",
                    Password = BCrypt.Net.BCrypt.HashPassword("Q@wertyuiop123"),
                    FirstName = "Kajetan",
                    LastName = "Stach",
                    Email = "kajetan.stach@wp.pl",
                    PhoneNumber = "123456789",
                    Role = "User"
                }
            );
        }
    }
}
