using System.Net;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using TaskTrackerUtilityApp.API.Data;
using TaskTrackerUtilityApp.API.Models;
using TaskTrackerUtilityApp.API.DTO;
using AutoMapper;

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ITaskAttachmentRepository _taskAttachmentRepository;
        private readonly IMapper _mapper;

        public FileController(IUnitOfWork unitOfWork, ITaskAttachmentRepository taskAttachmentRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;     
            _taskAttachmentRepository = taskAttachmentRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAttachment([FromBody] TaskAttachmentDTO taskAttachment)
        {
            var attachment = _mapper.Map<TaskAttachment>(taskAttachment);
            attachment.IsActive = true;
            attachment.CreatedDateTime = DateTime.Now;
            attachment.CreatedUser = "TaskAppUser"; //To Do:pass username

            _taskAttachmentRepository.Create(attachment);
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttachment(int id)
        {
            var attachment = _taskAttachmentRepository.FindByCondition(m=> m.Id == id).FirstOrDefault();
            if(attachment != null){
                _taskAttachmentRepository.Delete(attachment);
                _unitOfWork.Commit();
            }        
            return Ok();
        }
    }
}