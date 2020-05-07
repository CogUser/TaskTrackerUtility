namespace TaskTrackerUtilityApp.API.DTO
{
    public class TaskAttachmentDTO
    {
        public int Id {get; set;}
        public string FileName {get; set;}
        public string FileType {get; set;}
        public string FilePath {get; set;}
        public int TaskId {get; set;}
    }
}