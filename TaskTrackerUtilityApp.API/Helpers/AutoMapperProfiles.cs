using System.Collections.Generic;
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
            CreateMap<TaskAttachment, TaskAttachmentDTO>();           
        }
    }
}