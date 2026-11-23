using Microsoft.Maui.Controls;
using Route2.Models;
using Route2.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Route2.PagesApp;

public partial class SavedPlacesPage : ContentPage
{
    private readonly MapaService _mapaService;
    public ObservableCollection<LocalItem> Locals { get; set; }

    public SavedPlacesPage()
    {
        InitializeComponent();
        _mapaService = new MapaService();
        Locals = new ObservableCollection<LocalItem>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadLocalsAsync();
    }

    private async Task LoadLocalsAsync()
    {
        try
        {
            var locaisApi = await _mapaService.GetLocalsAsync();
            Locals.Clear();
            foreach (var local in locaisApi)
            {
                Locals.Add(local);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível carregar os locais: {ex.Message}", "OK");
        }
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnPlaceClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is LocalItem selectedLocal)
        {
            await Shell.Current.GoToAsync($"{nameof(PlaceDetailsPage)}?localId={selectedLocal.LocalID}");
        }
    }
}