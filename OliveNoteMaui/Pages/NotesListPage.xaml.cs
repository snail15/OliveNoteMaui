using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OliveNoteMaui.ViewModels;

namespace OliveNoteMaui.Pages;

public partial class NotesListPage : ContentPage
{
    public NotesListPage(NotesListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

