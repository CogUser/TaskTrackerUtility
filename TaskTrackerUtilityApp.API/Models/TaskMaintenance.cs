using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTrackerUtilityApp.API.Models
{
    public class TaskMaintenance
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TaskId { get; set; }
		public string TaskSummary { get; set; }
		public string TaskDescription { get; set; }
		public int Assignee { get; set; }
		public int AssignedTo { get; set; }
		public DateTime PlannedStartDate { get; set; }
		public DateTime PlannedEndDate { get; set; }
		public DateTime ActualStartDate { get; set; }
		public DateTime ActualEndDate { get; set; }
		public string Status { get; set; }
		public string Priority { get; set; }
		public string Progress { get; set; }
		public string Watchers { get; set; }
		public int CreatedBy { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public DateTime ModifiedDateTime { get; set; }
		public int UserId { get; set; }
    }
}
