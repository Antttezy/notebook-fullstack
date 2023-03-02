using Microsoft.EntityFrameworkCore;
using NotebookBackend.Data;
using NotebookBackend.Models;
using NotebookBackend.Services;

namespace NotebookBackend.Implementations;

public class NoteRepository : IRepository<Note>
{
    private readonly DatabaseContext _context;

    public NoteRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Note>> GetAll()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task Add(Note item)
    {
        await _context.Notes.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Note item)
    {
        _context.Notes.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Note?> GetById(int id)
    {
        return await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);
    }

    public async Task<IEnumerable<Note>> GetPage(int page)
    {
        return await _context.Notes
            .OrderBy(note => note.Id)
            .Skip((page - 1) * 20)
            .Take(20)
            .ToListAsync();
    }
}