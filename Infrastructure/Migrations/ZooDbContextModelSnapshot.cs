﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    partial class ZooDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Domain.Model.AnimalSponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("PriceOfFunding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartOfSponsoring")
                        .HasColumnType("datetime2");

                    b.Property<int>("zooUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("zooUserId");

                    b.ToTable("AnimalSponsors");
                });

            modelBuilder.Entity("Domain.Model.ZooUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalOwners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@domain.com",
                            FirstName = "admin",
                            LastName = "admin",
                            Login = "admin",
                            Password = "$2a$11$fLzRFx6ccBoVg66krYDs2uldQp7zvCvCMZHQLzWFS3FWhz5pdfmdy",
                            PhoneNumber = "111222333",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "kajetan.stach@wp.pl",
                            FirstName = "Kajetan",
                            LastName = "Stach",
                            Login = "Kajetan25",
                            Password = "$2a$11$6axIcIC9fF52/CaUQT3hE.vDb9fdblLwxp34KHl1ubbiLCNCqKSce",
                            PhoneNumber = "123456789",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Domain.Model.AnimalSponsor", b =>
                {
                    b.HasOne("Domain.Model.Animal", "Animal")
                        .WithMany("AnimalSponsors")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.ZooUser", "ZooUser")
                        .WithMany("AnimalSponsors")
                        .HasForeignKey("zooUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("ZooUser");
                });

            modelBuilder.Entity("Domain.Model.Animal", b =>
                {
                    b.Navigation("AnimalSponsors");
                });

            modelBuilder.Entity("Domain.Model.ZooUser", b =>
                {
                    b.Navigation("AnimalSponsors");
                });
#pragma warning restore 612, 618
        }
    }
}
