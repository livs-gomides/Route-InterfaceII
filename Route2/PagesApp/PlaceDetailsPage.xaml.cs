using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace Route2.PagesApp;

public partial class PlaceDetailsPage : ContentPage
{
    public ObservableCollection<Destination> Destinations { get; set; }

    public PlaceDetailsPage()
    {
        InitializeComponent();

        Destinations = new ObservableCollection<Destination>
        {
            new Destination { Name = "Biblioteca", LocationInfo = "Térreo" },
            new Destination { Name = "Banheiro", LocationInfo = "3º andar" },
            new Destination { Name = "Sala", LocationInfo = "4º andar" },
            new Destination { Name = "Burger King", LocationInfo = "Praça de Alimentação" },
            new Destination { Name = "McDonald's", LocationInfo = "Praça de Alimentação" }
        };

        BindingContext = this;
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnStartRouteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var destination = button?.BindingContext as Destination;

        if (destination != null)
        {
            await DisplayAlert("Rota", $"Simulando cálculo de rota para {destination.Name} (Integração BLE futura).", "OK");
        }
    }
}

public class Destination
{
    public string Name { get; set; }
    public string LocationInfo { get; set; }
}