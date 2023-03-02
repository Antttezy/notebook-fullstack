using Microsoft.EntityFrameworkCore;
using NotebookBackend.Models;

namespace NotebookBackend.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; } = null!;
}