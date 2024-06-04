using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Files.Commands;

namespace TaskBoard.Infrastructure.Controllers;
 
public class FileController : Controller
{
    private readonly IMediator _mediator;

    public FileController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Route("/files")]
    [Authorize]
    public async Task<IActionResult> AddFile(IFormFile file, LinkGenerator linker, HttpContext context)
    {
        var id = Guid.NewGuid();
        
        var fileSaveName = id.ToString("N") + Path.GetExtension(file.FileName);
        var path = await SaveFileWithCustomFileName(file, fileSaveName);

        var command = new CreateFileCommand()
        {
            Id = id,
            Name = file.FileName,
            Path = path
        };

        _mediator.Send(command);
        
        context.Response.Headers.Append("Location",
            linker.GetPathByName(context, "GetFileByName", new { fileName = fileSaveName }));
        return Ok("File Uploaded Successfully!");
    }
    
    [Route("/files/{fileName}")]
    [Authorize]
    public async Task<IActionResult> GetFile(string fileName)
    {
        var filePath = GetOrCreateFilePath(fileName);

        if (File.Exists(filePath))
        {
            return PhysicalFile(filePath, fileDownloadName: $"{fileName}");
        }

        return NotFound("No file found with the supplied file name");
    }
    
    async Task<string> SaveFileWithCustomFileName(IFormFile file, string fileSaveName)
    {
        var filePath = GetOrCreateFilePath(fileSaveName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return filePath;
    }
    
    string GetOrCreateFilePath(string fileName, string filesDirectory = "StaticFiles")
    {
        var directoryPath = Path.Combine(app.Environment.ContentRootPath, filesDirectory);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        return Path.Combine(app.Environment.ContentRootPath, directoryPath, fileName);
    }
}