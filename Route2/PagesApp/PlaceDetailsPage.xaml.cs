using Microsoft.Maui.Controls;
using Route2.Models;
using Route2.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Route2.PagesApp;

[QueryProperty(nameof(LocalId), "localId")]
[QueryProperty(nameof(LocalName), "localName")]
public partial class PlaceDetailsPage : ContentPage
{
    private readonly MapaService _mapaService;
    public ObservableCollection<Destination> Destinations { get; set; }
    public string LocalId { get; set; } = string.Empty;

    private string _localName = "Destinos Internos";
    public string LocalName
    {
        get => _localName;
        set
        {
            _localName = string.IsNullOrWhiteSpace(value)
                ? "Destinos Internos"
                : Uri.UnescapeDataString(value);

            if (PlaceTitleLabel != null)
                PlaceTitleLabel.Text = _localName;
        }
    }

    public PlaceDetailsPage()
    {
        InitializeComponent();
        _mapaService = new MapaService();
        Destinations = new ObservableCollection<Destination>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadSubLocalsAsync();
    }

    private async Task LoadSubLocalsAsync()
    {
        try
        {
            if (!Guid.TryParse(LocalId, out var parsedLocalId))
                return;

            var subLocaisApi = await _mapaService.GetSubLocalsByLocalIdAsync(parsedLocalId);
            Destinations.Clear();
            foreach (var subLocal in subLocaisApi)
            {
                Destinations.Add(new Destination
                {
                    Name = subLocal.Name,
                    LocationInfo = subLocal.FloorLevel == 0
                        ? "Térreo"
                        : $"{subLocal.FloorLevel}º andar"
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível carregar os destinos: {ex.Message}", "OK");
        }
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
    public string Name { get; set; } = string.Empty;
    public string LocationInfo { get; set; } = string.Empty;
}