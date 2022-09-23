using System;
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
                    digramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    digramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    digramJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digrams", x => x.digramId);
                });

            migrationBuilder.CreateTable(
                name: "forms",
                columns: table => new
                {
                    formGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    formName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    html = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forms", x => x.formGuid);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSult = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
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
                    nextProcessIdNo1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nextProcessIdNo2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    formId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_processes_forms_formId",
                        column: x => x.formId,
                        principalTable: "forms",
                        principalColumn: "formGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DigramsUser",
                columns: table => new
                {
                    adminUsersuserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    digramsdigramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigramsUser", x => new { x.adminUsersuserId, x.digramsdigramId });
                    table.ForeignKey(
                        name: "FK_DigramsUser_digrams_digramsdigramId",
                        column: x => x.digramsdigramId,
                        principalTable: "digrams",
                        principalColumn: "digramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigramsUser_user_adminUsersuserId",
                        column: x => x.adminUsersuserId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormsUser",
                columns: table => new
                {
                    adminUsersuserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    formsformGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsUser", x => new { x.adminUsersuserId, x.formsformGuid });
                    table.ForeignKey(
                        name: "FK_FormsUser_forms_formsformGuid",
                        column: x => x.formsformGuid,
                        principalTable: "forms",
                        principalColumn: "formGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormsUser_user_adminUsersuserId",
                        column: x => x.adminUsersuserId,
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
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    processId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.taskId);
                    table.ForeignKey(
                        name: "FK_tasks_processes_processId",
                        column: x => x.processId,
                        principalTable: "processes",
                        principalColumn: "processId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsUser",
                columns: table => new
                {
                    requestsrequsetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsUser", x => new { x.requestsrequsetId, x.userId });
                    table.ForeignKey(
                        name: "FK_RequestsUser_requests_requestsrequsetId",
                        column: x => x.requestsrequsetId,
                        principalTable: "requests",
                        principalColumn: "requsetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsUser_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "formVariable",
                columns: table => new
                {
                    FormVariablesGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formVariable", x => x.FormVariablesGUID);
                    table.ForeignKey(
                        name: "FK_formVariable_tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "tasks",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "runningRequests",
                columns: table => new
                {
                    runningRequeststId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    createOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    assigneeUseruserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_runningRequests", x => x.runningRequeststId);
                    table.ForeignKey(
                        name: "FK_runningRequests_tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "tasks",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_runningRequests_user_assigneeUseruserId",
                        column: x => x.assigneeUseruserId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasksUser",
                columns: table => new
                {
                    outhUseruserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    taskstaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksUser", x => new { x.outhUseruserId, x.taskstaskId });
                    table.ForeignKey(
                        name: "FK_TasksUser_tasks_taskstaskId",
                        column: x => x.taskstaskId,
                        principalTable: "tasks",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasksUser_user_outhUseruserId",
                        column: x => x.outhUseruserId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigramsUser_digramsdigramId",
                table: "DigramsUser",
                column: "digramsdigramId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsUser_formsformGuid",
                table: "FormsUser",
                column: "formsformGuid");

            migrationBuilder.CreateIndex(
                name: "IX_formVariable_taskId",
                table: "formVariable",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_processes_digramId",
                table: "processes",
                column: "digramId");

            migrationBuilder.CreateIndex(
                name: "IX_processes_formId",
                table: "processes",
                column: "formId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessesUser_processesprocessId",
                table: "ProcessesUser",
                column: "processesprocessId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsUser_userId",
                table: "RequestsUser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_runningRequests_assigneeUseruserId",
                table: "runningRequests",
                column: "assigneeUseruserId");

            migrationBuilder.CreateIndex(
                name: "IX_runningRequests_taskId",
                table: "runningRequests",
                column: "taskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_processId",
                table: "tasks",
                column: "processId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksUser_taskstaskId",
                table: "TasksUser",
                column: "taskstaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigramsUser");

            migrationBuilder.DropTable(
                name: "FormsUser");

            migrationBuilder.DropTable(
                name: "formVariable");

            migrationBuilder.DropTable(
                name: "ProcessesUser");

            migrationBuilder.DropTable(
                name: "RequestsUser");

            migrationBuilder.DropTable(
                name: "runningRequests");

            migrationBuilder.DropTable(
                name: "TasksUser");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "processes");

            migrationBuilder.DropTable(
                name: "digrams");

            migrationBuilder.DropTable(
                name: "forms");
        }
    }
}
