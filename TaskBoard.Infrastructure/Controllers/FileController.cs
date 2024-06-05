using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaskBoard.Application.Files.Commands;
using FileOptions = TaskBoard.Infrastructure.Options.FileOptions;

namespace TaskBoard.Infrastructure.Controllers;

public class FileController : Controller
{
    private readonly IMediator _mediator;
    private readonly FileOptions _fileOptions;

    public FileController(IMediator mediator, IOptions<FileOptions> options)
    {
        _mediator = mediator;
        _fileOptions = options.Value;
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

        if (System.IO.File.Exists(filePath))
        {
            return PhysicalFile(filePath, $"{fileName}");
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
        var directoryPath = Path.Combine(_fileOptions.Path, filesDirectory);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        return Path.Combine(_fileOptions.Path, directoryPath, fileName);
    }
}