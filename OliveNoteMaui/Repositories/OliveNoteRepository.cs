using OliveNoteMaui.Models;

namespace OliveNoteMaui.Repositories;

public class OliveNoteRepository : IOliveNoteRepository
{

    public event EventHandler<Note>? OnNoteAdded;
    public event EventHandler<Note>? OnNoteUpdated;
    public Task<List<Note>> GetNotesAsync()
    {
        throw new NotImplementedException();
    }
    public Task AddNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }
    public Task UpdateNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }
    public Task AddOrUpdateNoteAsync(Note note)
    {
        throw new NotImplementedException();
    }
}
