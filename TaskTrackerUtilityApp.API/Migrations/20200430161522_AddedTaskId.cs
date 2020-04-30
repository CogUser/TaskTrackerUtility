using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerUtilityApp.API.Migrations
{
    public partial class AddedTaskId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TaskAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskAttachments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "TaskAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "TaskAttachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "TaskAttachments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "TaskMaintenance",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "TaskAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "TaskAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "TaskAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TaskAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_TaskMaintenance_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "TaskMaintenance",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
