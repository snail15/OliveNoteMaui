using OliveNoteMaui.Models;

namespace OliveNoteMaui.Repositories;

public interface IOliveNoteRepository
{
    event EventHandler<Note> OnNoteAdded;
    event EventHandler<Note> OnNoteUpdated;
    
    Task<List<Note>> GetNotesAsync();
    Task AddNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task AddOrUpdateNoteAsync(Note note);
}
