using FileUploadWebApi.Data;
using FileUploadWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FileUploadWebApi.Repositories.FileUpload
{
    public class FileService : IFileService
    {
        //private readonly DbContextClass dbContextClass;

        //public FileService(DbContextClass dbContextClass)
        //{
        //    this.dbContextClass = dbContextClass;
        //}

        //public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        //{
        //    try
        //    {
        //        var fileDetails = new FileDetails()
        //        {
        //            ID = 0,
        //            FileName = fileData.FileName,
        //            FileType = fileType,
        //        };

        //        using (var stream = new MemoryStream())
        //        {
        //            fileData.CopyTo(stream);
        //            fileDetails.FileData = Convert.ToBase64String(stream.ToArray());
        //        }

        //        var result = dbContextClass.FileDetails.Add(fileDetails);
        //        await dbContextClass.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        //{
        //    try
        //    {
        //        foreach (FileUploadModel file in fileData)
        //        {
        //            var fileDetails = new FileDetails()
        //            {
        //                ID = 0,
        //                FileName = file.FileDetails.FileName,
        //                FileType = file.FileType,
        //            };

        //            using (var stream = new MemoryStream())
        //            {
        //                file.FileDetails.CopyTo(stream);
        //                fileDetails.FileData = Convert.ToBase64String(stream.ToArray());
        //            }

        //            var result = dbContextClass.FileDetails.Add(fileDetails);
        //        }
        //        await dbContextClass.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task DownloadFileById(int Id)
        //{
        //    try
        //    {
        //        var file = await dbContextClass.FileDetails.Where(x => x.ID == Id).FirstOrDefaultAsync();
        //        if (file != null)
        //        {
        //            byte[] fileDataBytes = Encoding.UTF8.GetBytes(file.FileData);

        //            var content = new System.IO.MemoryStream(fileDataBytes);
        //            var path = Path.Combine(
        //               Directory.GetCurrentDirectory(), "FileDownloaded",
        //               file.FileName);

        //            await CopyStream(content, path);
        //        }
        //        else
        //        {
        //            throw new Exception();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task CopyStream(Stream stream, string downloadPath)
        //{
        //    using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
        //    {
        //        await stream.CopyToAsync(fileStream);
        //    }
        //}
    }
}