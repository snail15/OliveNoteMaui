using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using OliveNoteMaui.Models;
using OliveNoteMaui.Repositories;

namespace OliveNoteMaui.ViewModels;

public partial class NotesListViewModel : BaseViewModel
{
    private readonly IDispatcher _dispatcher;
    private readonly IBaseRepository<Note> _baseRepository;
    [ObservableProperty] private ObservableCollection<NoteItemViewModel> _oliveNotes;

    public NotesListViewModel(IDispatcher dispatcher, IBaseRepository<Note> baseRepository)
    {
        _dispatcher = dispatcher;
        _baseRepository = baseRepository;
        _baseRepository.OnItemAdded += (sender, note) => OliveNotes.Add(CreateNoteItemViewModel(note));
        _baseRepository.OnItemUpdated += (sender, note) => Task.Run(async () => await LoadDataAsync());
        Task.Run(async () => await LoadDataAsync());
    }
    
    private async Task LoadDataAsync()
    {
        try
        {
            var notes = await _baseRepository.GetItemsAsync();
            var noteItemViewModels = notes.Select(note => CreateNoteItemViewModel(note));
            OliveNotes = new ObservableCollection<NoteItemViewModel>(noteItemViewModels);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private NoteItemViewModel CreateNoteItemViewModel(Note note)
    {
        var noteViewModel = new NoteItemViewModel(note);
        
        return noteViewModel;
    }
   
    
}
