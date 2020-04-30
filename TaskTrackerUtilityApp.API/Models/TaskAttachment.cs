using System.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTrackerUtilityApp.API.Models
{
    public class TaskAttachment
    {
        public int Id {get; set;}
        [Column("FileName")]
        public string FileName {get; set;}
        [Column("FileType")]
        public string FileType {get; set;}
        [Column("FilePath")]
        public string FilePath {get; set;}
        public string CreatedUser {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public bool IsActive {get; set;}
        public string LastModifiedUser {get; set;}
        public DateTime LastModifiedDateTime {get; set;}
        public int TaskId {get; set;}
        [ForeignKey("TaskId")] 
        public TaskMaintenance TaskMaintenance { get; set; }
    }
}