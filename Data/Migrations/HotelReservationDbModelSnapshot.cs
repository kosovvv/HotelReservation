﻿using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(HotelReservationDb))]
    partial class HotelReservationDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entity.Client", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);

                b.Property<bool>("IsAdult")
                    .HasColumnType("bit");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);

                b.Property<string>("TelephoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(12)")
                    .HasMaxLength(12);

                b.HasKey("Id");

                b.ToTable("Clients");
            });

            modelBuilder.Entity("Data.Entity.ClientReservation", b =>
            {
                b.Property<int>("ClientId")
                    .HasColumnType("int");

                b.Property<int>("ReservationId")
                    .HasColumnType("int");

                b.HasKey("ClientId", "ReservationId");

                b.HasIndex("ReservationId");

                b.ToTable("ClientReservation");
            });

            modelBuilder.Entity("Data.Entity.Reservation", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("DateOfAccommodation")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DateOfExemption")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsAllInclusive")
                    .HasColumnType("bit");

                b.Property<bool>("IsBreakfastIncluded")
                    .HasColumnType("bit");

                b.Property<decimal>("OverallBill")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("RoomId")
                    .HasColumnType("int");

                b.Property<int>("UserId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("RoomId");

                b.HasIndex("UserId");

                b.ToTable("Reservations");
            });

            modelBuilder.Entity("Data.Entity.Room", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("Capacity")
                    .HasColumnType("int");

                b.Property<bool>("IsFree")
                    .HasColumnType("bit");

                b.Property<int>("Number")
                    .HasColumnType("int");

                b.Property<decimal>("PriceAdult")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("PriceChild")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Rooms");
            });

            modelBuilder.Entity("Data.Entity.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime?>("DateOfBeingFired")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DateOfBeingHired")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime2");

                b.Property<string>("EGN")
                    .IsRequired()
                    .HasColumnType("nvarchar(10)")
                    .HasMaxLength(10);

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);

                b.Property<bool>("IsActive")
                    .HasColumnType("bit");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);

                b.Property<string>("MiddleName")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("TelephoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(12)")
                    .HasMaxLength(12);

                b.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("nvarchar(20)")
                    .HasMaxLength(20);

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("Data.Entity.ClientReservation", b =>
            {
                b.HasOne("Data.Entity.Client", "Client")
                    .WithMany("Reservations")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Data.Entity.Reservation", "Reservation")
                    .WithMany("Clients")
                    .HasForeignKey("ReservationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Data.Entity.Reservation", b =>
            {
                b.HasOne("Data.Entity.Room", "Room")
                    .WithMany("Reservations")
                    .HasForeignKey("RoomId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Data.Entity.User", "User")
                    .WithMany("Reservations")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
