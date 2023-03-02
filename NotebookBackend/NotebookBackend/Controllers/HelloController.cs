using Microsoft.AspNetCore.Mvc;
using NotebookBackend.Models;
using NotebookBackend.Models.Dto;
using NotebookBackend.Services;

namespace NotebookBackend.Controllers;

[ApiController]
[Route("api/notes")]
public class HelloController : ControllerBase
{
    private readonly IRepository<Note> _repository;

    public HelloController(IRepository<Note> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("")]
    public async Task<IEnumerable<Note>> GetNotes([FromQuery] int page)
    {
        return await _repository.GetPage(page);
    }
    
    [HttpPost]
    [Route("add")]
    public async Task<Note> AddNote([FromBody] NoteDto note)
    {
        Note toAdd = new(note.Name, note.Content);
        await _repository.Add(toAdd);
        return toAdd;
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task DeleteNote([FromRoute] int id)
    {
        Note? toDelete = await _repository.GetById(id);

        if (toDelete is null)
        {
            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }
        
        await _repository.Remove(toDelete);
    }
}