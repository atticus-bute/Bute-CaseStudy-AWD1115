﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsPro.Models;

#nullable disable

namespace SportsPro.Migrations
{
    [DbContext(typeof(SportsProContext))]
    partial class SportsProContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.Property<int>("RegisteredCustomersCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("RegisteredProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("RegisteredCustomersCustomerId", "RegisteredProductsProductId");

                    b.HasIndex("RegisteredProductsProductId");

                    b.ToTable("CustomerProduct");

                    b.HasData(
                        new
                        {
                            RegisteredCustomersCustomerId = 1,
                            RegisteredProductsProductId = 1
                        },
                        new
                        {
                            RegisteredCustomersCustomerId = 1,
                            RegisteredProductsProductId = 2
                        },
                        new
                        {
                            RegisteredCustomersCustomerId = 1,
                            RegisteredProductsProductId = 3
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = "usa",
                            Name = "United States"
                        },
                        new
                        {
                            CountryId = "can",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = "mex",
                            Name = "Mexico"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "1234 Main St",
                            City = "Beverly Hills",
                            CountryId = "usa",
                            Email = "jaogg@mail.com",
                            FirstName = "Candy",
                            LastName = "Kong",
                            Phone = "123465888",
                            PostalCode = "90210",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            DateOpened = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Title"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("AnnualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            AnnualPrice = 4.99m,
                            Name = "Tournament Master 1.0",
                            ProductCode = "TRNY10",
                            ReleaseDate = new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 2,
                            AnnualPrice = 4.99m,
                            Name = "League Scheduler 1.0",
                            ProductCode = "LEAG10",
                            ReleaseDate = new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 3,
                            AnnualPrice = 4.99m,
                            Name = "Team Manager 1.0",
                            ProductCode = "TEAM10",
                            ReleaseDate = new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 4,
                            AnnualPrice = 5.99m,
                            Name = "Tournament Master 2.0",
                            ProductCode = "TRNY20",
                            ReleaseDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 5,
                            AnnualPrice = 5.99m,
                            Name = "League Scheduler 2.0",
                            ProductCode = "LEAG20",
                            ReleaseDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 6,
                            AnnualPrice = 5.99m,
                            Name = "Team Manager 2.0",
                            ProductCode = "TEAM20",
                            ReleaseDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SportsPro.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "asdf@asdf.com",
                            FirstName = "Hector",
                            LastName = "Lector",
                            Phone = "123465888"
                        });
                });

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.HasOne("SportsPro.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("RegisteredCustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("RegisteredProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsPro.Models.Customer", b =>
                {
                    b.HasOne("SportsPro.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SportsPro.Models.Incident", b =>
                {
                    b.HasOne("SportsPro.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
