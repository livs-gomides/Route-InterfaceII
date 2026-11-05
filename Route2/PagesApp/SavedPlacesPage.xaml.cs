using Microsoft.Maui.Controls;
using System;

namespace Route2.PagesApp;

public partial class SavedPlacesPage : ContentPage
{
    public SavedPlacesPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    // Navega para a tela de detalhes quando qualquer local é clicado
    private async void OnPlaceClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PlaceDetailsPage));
    }
}