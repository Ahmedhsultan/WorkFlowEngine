using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tasks_processId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_requests_startProcessesId",
                table: "requests");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_processId",
                table: "tasks",
                column: "processId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tasks_processId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_requests_startProcessesId",
                table: "requests");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_processId",
                table: "tasks",
                column: "processId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requests_startProcessesId",
                table: "requests",
                column: "startProcessesId",
                unique: true);
        }
    }
}
