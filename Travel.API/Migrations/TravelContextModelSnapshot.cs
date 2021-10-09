﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.API.Infrastructure;

namespace Travel.API.Migrations
{
    [DbContext(typeof(TravelContext))]
    partial class TravelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Travel.API.Model.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentActivityType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ActivityId");

                    b.HasIndex("CityId");

                    b.ToTable("TravelActivities");
                });

            modelBuilder.Entity("Travel.API.Model.Boarding", b =>
                {
                    b.Property<int>("BoardingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("BoardingId");

                    b.HasIndex("CityId");

                    b.ToTable("TravelBoardings");
                });

            modelBuilder.Entity("Travel.API.Model.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("TripId");

                    b.ToTable("TravelCities");
                });

            modelBuilder.Entity("Travel.API.Model.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.ToTable("TravelTrips");
                });

            modelBuilder.Entity("Travel.API.Model.Activity", b =>
                {
                    b.HasOne("Travel.API.Model.City", null)
                        .WithMany("Activities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travel.API.Model.Boarding", b =>
                {
                    b.HasOne("Travel.API.Model.City", null)
                        .WithMany("Boardings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travel.API.Model.City", b =>
                {
                    b.HasOne("Travel.API.Model.Trip", null)
                        .WithMany("Cities")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travel.API.Model.City", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Boardings");
                });

            modelBuilder.Entity("Travel.API.Model.Trip", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}