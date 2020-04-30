using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerUtilityApp.API.Migrations
{
    public partial class TaskAttachmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskMaintenanceTaskId",
                table: "TaskAttachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_TaskMaintenanceTaskId",
                table: "TaskAttachments",
                column: "TaskMaintenanceTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskMaintenanceTaskId",
                table: "TaskAttachments",
                column: "TaskMaintenanceTaskId",
                principalTable: "TaskMaintenance",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskMaintenanceTaskId",
                table: "TaskAttachments");

            migrationBuilder.DropIndex(
                name: "IX_TaskAttachments_TaskMaintenanceTaskId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "TaskMaintenanceTaskId",
                table: "TaskAttachments");
        }
    }
}
