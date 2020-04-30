using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerUtilityApp.API.Migrations
{
    public partial class RenamedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "Title", newName: "FileName");
            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "ContentType", newName: "FileType");
            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "Path", newName: "FilePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "FileName", newName: "Title");
            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "FileType", newName: "ContentType");
            migrationBuilder.RenameColumn(table: "dbo.TaskAttachments", name: "FilePath", newName: "Path");
        }
    }
}
