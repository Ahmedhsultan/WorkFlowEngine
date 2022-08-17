﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220817162840_tables")]
    partial class tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Models.Digrams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DigramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("digrams");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("digramsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("divAttribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("nextProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("script")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("digramsId");

                    b.ToTable("processes");
                });

            modelBuilder.Entity("Database.Models.Requests", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("startProcessesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("guid");

                    b.HasIndex("startProcessesId");

                    b.HasIndex("userId");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProcessesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessesId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.HasOne("Database.Models.Digrams", "digrams")
                        .WithMany()
                        .HasForeignKey("digramsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("digrams");
                });

            modelBuilder.Entity("Database.Models.Requests", b =>
                {
                    b.HasOne("Database.Models.Processes", "startProcesses")
                        .WithMany()
                        .HasForeignKey("startProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("startProcesses");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.HasOne("Database.Models.Processes", null)
                        .WithMany("user")
                        .HasForeignKey("ProcessesId");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
