﻿// <auto-generated />
using System;
using Altaliza.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Altaliza.Infra.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Altaliza.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<float>("Wallet")
                        .HasColumnType("float")
                        .HasColumnName("Wallet");

                    b.HasKey("Id");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.CharacterVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("ExpirationDate");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("VehicleId");

                    b.ToTable("characters_vehicles");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<float>("Rent15Day")
                        .HasColumnType("float")
                        .HasColumnName("Rent15Day");

                    b.Property<float>("Rent1Day")
                        .HasColumnType("float")
                        .HasColumnName("Rent1Day");

                    b.Property<float>("Rent7Day")
                        .HasColumnType("float")
                        .HasColumnName("Rent7Day");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("vehicles");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.VehicleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("vehicles_categories");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.CharacterVehicle", b =>
                {
                    b.HasOne("Altaliza.Domain.Entities.Character", "Character")
                        .WithMany("Vehicles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Altaliza.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("CharacterVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Character");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("Altaliza.Domain.Entities.VehicleCategory", "Category")
                        .WithMany("Vehicles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.Character", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("CharacterVehicles");
                });

            modelBuilder.Entity("Altaliza.Domain.Entities.VehicleCategory", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
