using FileUploadWebApi.Data;
using FileUploadWebApi.Models;
using FileUploadWebApi.Repositories.FileUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileUploadWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        //private readonly IFileService _uploadService;
        private readonly DbContextClass context;

        public FilesController(IFileService uploadService, DbContextClass context)
        {
            //_uploadService = uploadService;
            this.context = context;
        }

        [HttpPost]
        [Route("/addFile")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            Console.WriteLine(file.FileName);
            try
            {
                byte[] fileData;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                var fileDetails = new FileDetails
                {
                    FileName = file.FileName,
                    File = fileData,
                    FileType = file.ContentType
                };

                context.Add(fileDetails);
                context.SaveChanges();
                return Ok(new { fileId = fileDetails.ID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/getFile/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            // Find the FileDetails entity with the specified ID
            var fileDetails = await context.FileDetails.FindAsync(id);
            if (fileDetails == null)
            {
                return NotFound();
            }

            // Return the file content as a downloadable file
            return File(fileDetails.File, fileDetails.FileType, fileDetails.FileName);
        }

        [HttpGet]
        [Route("/getAllFile")]
        public async Task<IActionResult> GetAllFile(int id)
        {
            // Find the FileDetails entity with the specified ID
            var fileDetailsList = await context.FileDetails.ToListAsync();
            if (fileDetailsList.Count == 0)
            {
                return NotFound();
            }

            var fileDetailsResponse = fileDetailsList.Select(f => new
            {
                ID = f.ID,
                FileName = f.FileName,
                FileType = f.FileType
            }).ToList();

            //for (var i = 0; i < fileDetailsList.Count; i++)
            //{
            //    fileDetailsList[i] = File(fileDetailsList[i].File, fileDetailsList[i].FileType, fileDetailsList[i].FileName);
            //}

            return Ok(fileDetailsResponse);
        }

        //[HttpPost("PostSingleFile")]
        //public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        //{
        //    if (fileDetails == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _uploadService.PostFileAsync(fileDetails.FileDetails, fileDetails.FileType);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost("PostMultipleFile")]
        //public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        //{
        //    if (fileDetails == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _uploadService.PostMultiFileAsync(fileDetails);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpGet("DownloadFile")]
        //public async Task<ActionResult> DownloadFile(int id)
        //{
        //    if (id < 1)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _uploadService.DownloadFileById(id);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
