using System;

namespace TaskTrackerUtilityApp.API.Models
{
    public class TaskAttachment
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string ContentType {get; set;}
        public string Path {get; set;}
        public string CreatedUser {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public bool IsActive {get; set;}
        public string LastModifiedUser {get; set;}
        public DateTime LastModifiedDateTime {get; set;}
    }
}