﻿// <auto-generated />
using System;
using ArchitectDevicesCR.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchitectDevicesCR.Migrations
{
    [DbContext(typeof(DevicesContext))]
    [Migration("20210126231759_V9")]
    partial class V9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId");

                    b.Property<DateTime>("Since");

                    b.Property<DateTime>("Until");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.CheckoutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("DeviceId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("CheckoutHistories");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<string>("OS")
                        .IsRequired();

                    b.Property<int>("SiteId");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("StatusId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceId");

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("SiteId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Checkout", b =>
                {
                    b.HasOne("ArchitectDevicesCR.DataModels.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArchitectDevicesCR.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.CheckoutHistory", b =>
                {
                    b.HasOne("ArchitectDevicesCR.DataModels.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArchitectDevicesCR.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Device", b =>
                {
                    b.HasOne("ArchitectDevicesCR.DataModels.Site", "Site")
                        .WithMany("Devices")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArchitectDevicesCR.DataModels.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.Hold", b =>
                {
                    b.HasOne("ArchitectDevicesCR.DataModels.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("ArchitectDevicesCR.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ArchitectDevicesCR.DataModels.User", b =>
                {
                    b.HasOne("ArchitectDevicesCR.DataModels.Site", "Site")
                        .WithMany("Users")
                        .HasForeignKey("SiteId");
                });
#pragma warning restore 612, 618
        }
    }
}