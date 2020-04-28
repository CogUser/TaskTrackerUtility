using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerUtilityApp.API.Migrations
{
    public partial class InitialTaskMainenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskMaintenance",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskSummary = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    Assignee = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<int>(nullable: false),
                    PlannedStartDate = table.Column<DateTime>(nullable: false),
                    PlannedEndDate = table.Column<DateTime>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    Progress = table.Column<string>(nullable: true),
                    Watchers = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMaintenance", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskMaintenance");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
