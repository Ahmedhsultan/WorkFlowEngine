using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class t : Migration
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
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
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
                name: "ProcessesUser",
                columns: table => new
                {
                    outhUseruserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    processesprocessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessesUser", x => new { x.outhUseruserId, x.processesprocessId });
                    table.ForeignKey(
                        name: "FK_ProcessesUser_processes_processesprocessId",
                        column: x => x.processesprocessId,
                        principalTable: "processes",
                        principalColumn: "processId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessesUser_user_outhUseruserId",
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
                name: "IX_ProcessesUser_processesprocessId",
                table: "ProcessesUser",
                column: "processesprocessId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requests_userId",
                table: "requests",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigramsUser");

            migrationBuilder.DropTable(
                name: "ProcessesUser");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "processes");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "digrams");
        }
    }
}
