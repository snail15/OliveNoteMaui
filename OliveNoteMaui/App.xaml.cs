using OliveNoteMaui.Pages;
using OliveNoteMaui.ViewModels;

namespace OliveNoteMaui;

public partial class App : Application
{
    public App(NotesListPage page)
    {
        InitializeComponent();

        MainPage = new NavigationPage(page);
    }
}
