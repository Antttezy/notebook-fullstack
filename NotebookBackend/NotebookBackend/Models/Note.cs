using Microsoft.EntityFrameworkCore;

namespace NotebookBackend.Models;

[PrimaryKey(nameof(Id))]
public class Note
{
    public Note(string name, string content)
    {
        Name = name;
        Content = content;
        Id = 0;
    }
    
    public Note(int id, string name, string content)
    {
        Name = name;
        Content = content;
        Id = id;
    }

    public int Id { get; }

    public string Name { get; set; }

    public string Content { get; set; }
}