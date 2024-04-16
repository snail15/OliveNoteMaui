using OliveNoteMaui.Pages;

namespace OliveNoteMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new TabPage();
    }
}
