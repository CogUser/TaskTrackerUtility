using System.ComponentModel.Design;
using System.ComponentModel;
using AutoMapper;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.DTO;

namespace TaskTrackerUtilityApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskAttachmentDTO, TaskAttachment>();             
        }
    }
}