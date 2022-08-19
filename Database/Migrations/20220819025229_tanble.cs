using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class tanble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "digrams",
                columns: table => new
                {
                    digramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    digramName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digrams", x => x.digramId);
                });

            migrationBuilder.CreateTable(
                name: "processes",
                columns: table => new
                {
                    processId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    formId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    scriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start = table.Column<bool>(type: "bit", nullable: false),
                    end = table.Column<bool>(type: "bit", nullable: false),
                    nextProcessIdNo1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nextProcessIdNo2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    digramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.processId);
                    table.ForeignKey(
                        name: "FK_processes_digrams_digramId",
                        column: x => x.digramId,
                        principalTable: "digrams",
                        principalColumn: "digramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSult = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    ProcessesprocessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                    table.ForeignKey(
                        name: "FK_user_processes_ProcessesprocessId",
                        column: x => x.ProcessesprocessId,
                        principalTable: "processes",
                        principalColumn: "processId");
                });

            migrationBuilder.CreateTable(
                name: "DigramsUser",
                columns: table => new
                {
                    digramsdigramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    outhUseruserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigramsUser", x => new { x.digramsdigramId, x.outhUseruserId });
                    table.ForeignKey(
                        name: "FK_DigramsUser_digrams_digramsdigramId",
                        column: x => x.digramsdigramId,
                        principalTable: "digrams",
                        principalColumn: "digramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigramsUser_user_outhUseruserId",
                        column: x => x.outhUseruserId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    requsetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startProcessesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.requsetId);
                    table.ForeignKey(
                        name: "FK_requests_processes_startProcessesId",
                        column: x => x.startProcessesId,
                        principalTable: "processes",
                        principalColumn: "processId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigramsUser_outhUseruserId",
                table: "DigramsUser",
                column: "outhUseruserId");

            migrationBuilder.CreateIndex(
                name: "IX_processes_digramId",
                table: "processes",
                column: "digramId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requests_userId",
                table: "requests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ProcessesprocessId",
                table: "user",
                column: "ProcessesprocessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigramsUser");

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
