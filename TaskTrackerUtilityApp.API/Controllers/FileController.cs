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

namespace TaskTrackerUtilityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ITaskAttachmentRepository _taskAttachmentRepository;

        public FileController(IUnitOfWork unitOfWork, ITaskAttachmentRepository taskAttachmentRepository)
        {
            _unitOfWork = unitOfWork;     
            _taskAttachmentRepository = taskAttachmentRepository;
        }
        
    public IActionResult Upload()
    {
        try
        {
            var files = Request.Form.Files;
            var folderName = Path.Combine("Resources","Attachments");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if(files.Any(f => f.Length == 0))
            {
                return BadRequest();
            }

            foreach(var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Replace("\"",string.Empty);
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName); 
 
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok("All the files are successfully uploaded.");
        }   
        catch (Exception)
            {
            return StatusCode(500, "Internal server error");
        }
    }
    }
}