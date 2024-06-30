using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ZooDbContext : IdentityDbContext<ZooUser>
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base (options) 
        { }

        public DbSet<Animal> Animals { get; set; } = default!;
        public DbSet<ZooUser> AnimalOwners { get; set; } = default!;
        public DbSet<AnimalSponsor> AnimalSponsors { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string adminId = Guid.NewGuid().ToString();

            string adminRoleId = Guid.NewGuid().ToString();
            string employeeRoleId = Guid.NewGuid().ToString();

            PasswordHasher<ZooUser> passwordHasher = new PasswordHasher<ZooUser>();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "adminRole",
                    NormalizedName = "ADMINROLE",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                },
                new IdentityRole
                {
                    Name = "employee",
                    NormalizedName = "EMPLOYEE",
                    Id = employeeRoleId,
                    ConcurrencyStamp = employeeRoleId,
                });

            var admin = new ZooUser
            {
                Id = adminId,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@wp.pl",
                EmailConfirmed = true,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@WP.PL"
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!@#");

            builder.Entity<ZooUser>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>()
                .HasData
                (
                    new IdentityUserRole<string>
                    {
                        UserId = adminId,
                        RoleId = adminRoleId,
                    }
                );

            builder.Entity<AnimalSponsor>()
                .HasOne(a => a.ZooUser)
                .WithMany(z => z.AnimalSponsors)
                .HasForeignKey(a => a.UserName)
                .IsRequired();

        }
    }
}
