﻿// <auto-generated />
using CarShowRoom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CarShowRoom.Migrations
{
    [DbContext(typeof(CarShowRoomContext))]
    partial class CarShowRoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("CarShowRoom.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color")
                        .HasMaxLength(100);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Modifcn")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ProviderId");

                    b.Property<DateTime>("ReceiptDate");

                    b.Property<int>("SpecsId");

                    b.Property<decimal>("StarterPrice")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("SpecsId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarShowRoom.Models.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImage");
                });

            modelBuilder.Entity("CarShowRoom.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("CarShowRoom.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarShowRoom.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("HireDate");

                    b.Property<int>("PersonId");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CarShowRoom.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<int>("CustomerId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CarShowRoom.Models.PayMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("PayMethod");
                });

            modelBuilder.Entity("CarShowRoom.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactInfoId");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("CarShowRoom.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("CarShowRoom.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactInfoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId")
                        .IsUnique();

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("CarShowRoom.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CarShowRoom.Models.TechSpecs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("EngineVolume")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("FuelConsumption")
                        .HasColumnType("decimal(8,2)");

                    b.Property<short>("Height");

                    b.Property<short>("Length");

                    b.Property<short>("MaxSpeed");

                    b.Property<byte>("NumOfSeats");

                    b.Property<string>("SupplySystem")
                        .HasMaxLength(100);

                    b.Property<short>("Weight");

                    b.Property<short>("Width");

                    b.HasKey("Id");

                    b.ToTable("TechSpecs");
                });

            modelBuilder.Entity("CarShowRoom.Models.Car", b =>
                {
                    b.HasOne("CarShowRoom.Models.Provider", "Provider")
                        .WithMany("Cars")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarShowRoom.Models.TechSpecs", "Specs")
                        .WithOne("Car")
                        .HasForeignKey("CarShowRoom.Models.Car", "SpecsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarShowRoom.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.CarImage", b =>
                {
                    b.HasOne("CarShowRoom.Models.Car", "Car")
                        .WithMany("CarImages")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.Customer", b =>
                {
                    b.HasOne("CarShowRoom.Models.Person", "Person")
                        .WithOne("Customer")
                        .HasForeignKey("CarShowRoom.Models.Customer", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.Employee", b =>
                {
                    b.HasOne("CarShowRoom.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("CarShowRoom.Models.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarShowRoom.Models.Position", "Position")
                        .WithOne("Employee")
                        .HasForeignKey("CarShowRoom.Models.Employee", "PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.Order", b =>
                {
                    b.HasOne("CarShowRoom.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarShowRoom.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.Person", b =>
                {
                    b.HasOne("CarShowRoom.Models.ContactInfo", "ContactInfo")
                        .WithOne("Person")
                        .HasForeignKey("CarShowRoom.Models.Person", "ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarShowRoom.Models.Provider", b =>
                {
                    b.HasOne("CarShowRoom.Models.ContactInfo", "ContactInfo")
                        .WithOne("Provider")
                        .HasForeignKey("CarShowRoom.Models.Provider", "ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
