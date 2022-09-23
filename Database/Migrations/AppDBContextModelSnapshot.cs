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

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("digramJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("digramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("digramId");

                    b.ToTable("digrams");
                });

            modelBuilder.Entity("Database.Models.Forms", b =>
                {
                    b.Property<Guid>("formGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("formName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("html")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("json")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("formGuid");

                    b.ToTable("forms");
                });

            modelBuilder.Entity("Database.Models.FormVariable", b =>
                {
                    b.Property<Guid>("FormVariablesGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("taskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormVariablesGUID");

                    b.HasIndex("taskId");

                    b.ToTable("formVariable");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Property<Guid>("processId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("digramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("formId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nextProcessIdNo1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("nextProcessIdNo2")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("processId");

                    b.HasIndex("digramId");

                    b.HasIndex("formId");

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

                    b.HasIndex("startProcessesId");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("Database.Models.RunningRequests", b =>
                {
                    b.Property<Guid>("runningRequeststId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("assigneeUseruserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("requestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<Guid>("taskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("runningRequeststId");

                    b.HasIndex("assigneeUseruserId");

                    b.HasIndex("taskId")
                        .IsUnique();

                    b.ToTable("runningRequests");
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

                    b.Property<string>("taskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("taskId");

                    b.HasIndex("processId");

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

            modelBuilder.Entity("FormsUser", b =>
                {
                    b.Property<Guid>("adminUsersuserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("formsformGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("adminUsersuserId", "formsformGuid");

                    b.HasIndex("formsformGuid");

                    b.ToTable("FormsUser");
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

            modelBuilder.Entity("Database.Models.FormVariable", b =>
                {
                    b.HasOne("Database.Models.Tasks", "task")
                        .WithMany("formVariable")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("task");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.HasOne("Database.Models.Digrams", "digram")
                        .WithMany("processes")
                        .HasForeignKey("digramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Forms", "form")
                        .WithMany("assumerProcesses")
                        .HasForeignKey("formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("digram");

                    b.Navigation("form");
                });

            modelBuilder.Entity("Database.Models.Requests", b =>
                {
                    b.HasOne("Database.Models.Processes", "startProcesses")
                        .WithMany("request")
                        .HasForeignKey("startProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("startProcesses");
                });

            modelBuilder.Entity("Database.Models.RunningRequests", b =>
                {
                    b.HasOne("Database.Models.User", "assigneeUser")
                        .WithMany("runningRequests")
                        .HasForeignKey("assigneeUseruserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Tasks", "task")
                        .WithOne("runningRequests")
                        .HasForeignKey("Database.Models.RunningRequests", "taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assigneeUser");

                    b.Navigation("task");
                });

            modelBuilder.Entity("Database.Models.Tasks", b =>
                {
                    b.HasOne("Database.Models.Processes", "process")
                        .WithMany("task")
                        .HasForeignKey("processId")
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

            modelBuilder.Entity("FormsUser", b =>
                {
                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("adminUsersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Forms", null)
                        .WithMany()
                        .HasForeignKey("formsformGuid")
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

            modelBuilder.Entity("Database.Models.Forms", b =>
                {
                    b.Navigation("assumerProcesses");
                });

            modelBuilder.Entity("Database.Models.Processes", b =>
                {
                    b.Navigation("request");

                    b.Navigation("task");
                });

            modelBuilder.Entity("Database.Models.Tasks", b =>
                {
                    b.Navigation("formVariable");

                    b.Navigation("runningRequests")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Navigation("runningRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
