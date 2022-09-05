﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Models.Digrams", b =>
                {
                    b.Property<Guid>("digramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("digramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("digramId");

                    b.ToTable("digrams");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Property<Guid>("processId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("digramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("end")
                        .HasColumnType("bit");

                    b.Property<Guid>("formId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nextProcessIdNo1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nextProcessIdNo2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("scriptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("start")
                        .HasColumnType("bit");

                    b.HasKey("processId");

                    b.HasIndex("digramId");

                    b.ToTable("processes");
                });

            modelBuilder.Entity("Database.Models.Requests", b =>
                {
                    b.Property<Guid>("requsetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("startProcessesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("requsetId");

                    b.HasIndex("startProcessesId")
                        .IsUnique();

                    b.ToTable("requests");
                });

            modelBuilder.Entity("Database.Models.Tasks", b =>
                {
                    b.Property<Guid>("taskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("processId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("requestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("taskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("taskId");

                    b.HasIndex("processId")
                        .IsUnique();

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSult")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DigramsUser", b =>
                {
                    b.Property<Guid>("adminUsersuserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("digramsdigramId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("adminUsersuserId", "digramsdigramId");

                    b.HasIndex("digramsdigramId");

                    b.ToTable("DigramsUser");
                });

            modelBuilder.Entity("ProcessesUser", b =>
                {
                    b.Property<Guid>("outhUseruserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("processesprocessId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("outhUseruserId", "processesprocessId");

                    b.HasIndex("processesprocessId");

                    b.ToTable("ProcessesUser");
                });

            modelBuilder.Entity("RequestsUser", b =>
                {
                    b.Property<Guid>("requestsrequsetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("requestsrequsetId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("RequestsUser");
                });

            modelBuilder.Entity("TasksUser", b =>
                {
                    b.Property<Guid>("outhUseruserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("taskstaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("outhUseruserId", "taskstaskId");

                    b.HasIndex("taskstaskId");

                    b.ToTable("TasksUser");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.HasOne("Database.Models.Digrams", "digram")
                        .WithMany("processes")
                        .HasForeignKey("digramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("digram");
                });

            modelBuilder.Entity("Database.Models.Requests", b =>
                {
                    b.HasOne("Database.Models.Processes", "startProcesses")
                        .WithOne("request")
                        .HasForeignKey("Database.Models.Requests", "startProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("startProcesses");
                });

            modelBuilder.Entity("Database.Models.Tasks", b =>
                {
                    b.HasOne("Database.Models.Processes", "process")
                        .WithOne("task")
                        .HasForeignKey("Database.Models.Tasks", "processId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("process");
                });

            modelBuilder.Entity("DigramsUser", b =>
                {
                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("adminUsersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Digrams", null)
                        .WithMany()
                        .HasForeignKey("digramsdigramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProcessesUser", b =>
                {
                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("outhUseruserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Processes", null)
                        .WithMany()
                        .HasForeignKey("processesprocessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RequestsUser", b =>
                {
                    b.HasOne("Database.Models.Requests", null)
                        .WithMany()
                        .HasForeignKey("requestsrequsetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TasksUser", b =>
                {
                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("outhUseruserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Tasks", null)
                        .WithMany()
                        .HasForeignKey("taskstaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Digrams", b =>
                {
                    b.Navigation("processes");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Navigation("request")
                        .IsRequired();

                    b.Navigation("task")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
