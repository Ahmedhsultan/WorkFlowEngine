﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "digrams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DigramName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digrams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    digramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    form = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    script = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start = table.Column<bool>(type: "bit", nullable: false),
                    end = table.Column<bool>(type: "bit", nullable: false),
                    nextProcessIdNo1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nextProcessIdNo2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_processes_digrams_digramId",
                        column: x => x.digramId,
                        principalTable: "digrams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSult = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    ProcessesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalTable: "processes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startProcessesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requests_processes_startProcessesId",
                        column: x => x.startProcessesId,
                        principalTable: "processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processes_digramId",
                table: "processes",
                column: "digramId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_userId",
                table: "requests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ProcessesId",
                table: "user",
                column: "ProcessesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "processes");

            migrationBuilder.DropTable(
                name: "digrams");
        }
    }
}