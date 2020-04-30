using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerUtilityApp.API.Migrations
{
    public partial class RenamedTaskAttachmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "TaskAttachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_TaskId",
                table: "TaskAttachments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "TaskMaintenance",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropIndex(
                name: "IX_TaskAttachments_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TaskAttachments");

            migrationBuilder.AddColumn<int>(
                name: "TaskMaintenanceTaskId",
                table: "TaskAttachments",
                type: "int",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
