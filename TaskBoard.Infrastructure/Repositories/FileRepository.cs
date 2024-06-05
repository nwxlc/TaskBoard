using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using File = TaskBoard.Domain.Models.File;

namespace TaskBoard.Infrastructure.Repositories;

public class FileRepository : IFileRepository
{
    private readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Create(File entity)
    {
        await _context.Files.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
    
    public async Task<File> TryGetById(Guid id)
    {
        return await _context.Files
                   .FirstOrDefaultAsync(x => x.Id == id)
               ?? throw new ArgumentException("File not found");
    }
}