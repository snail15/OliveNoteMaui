using CommunityToolkit.Mvvm.ComponentModel;
using OliveNoteMaui.Models;

namespace OliveNoteMaui.ViewModels;

public partial class NoteItemViewModel : ObservableObject
{
    [ObservableProperty] private Note _note;
    public NoteItemViewModel(Note note)
    {
        Note = note;
    }
}
