using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OliveNoteMaui.Models;
using OliveNoteMaui.Pages;
using OliveNoteMaui.Repositories;
using OliveNoteMaui.ViewModels;

namespace OliveNoteMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
           .UseMauiApp<App>()
           .UseMauiCommunityToolkit()
           .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
           .RegisterServices()
           .RegisterViewModels()
           .RegisterViews();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        //builder.Services.AddSingleton<typeof(IBaseRepository<Note>), typeof(BaseRepository<Note>)>();
        return builder;
    }
    
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<CreateNoteViewModel>();
        builder.Services.AddTransient<NotesListViewModel>();
        return builder;
    }
    
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<CreateNotePage>();
        builder.Services.AddTransient<NotesListPage>();
        return builder;
    }
}
