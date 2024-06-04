namespace TaskBoard.Domain.Models;

public class File
{
    private File(Guid id, string name, string path)
    {
        Id = id;
        Name = name;
        Path = path;
    }
    
    public Guid Id { get; set; }

    public string Path { get; set; }
    
    public string Name { get; set; }
    
    public static File Create(Guid id, string name, string path)
    {
        var file = new File(id, name, path);

        return file;
    }
}